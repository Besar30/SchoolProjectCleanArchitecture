using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Authrization.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Commands.Handlers
{
    public class AuthorizationCommandHandler(IAuthrizationServices authorizationService,RoleManager<ApplicationRole> roleManager,ApplicationDBContext context): IRequestHandler<AddRoleCommand, Result<string>>
                                                                                                                                                                ,IRequestHandler<UpdateRoleCommand ,Result<string>>,
                                                                                                                                                                 IRequestHandler<ToggleStatusCommand ,Result<bool>>                   
    {
        private readonly IAuthrizationServices _authorizationService = authorizationService;
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
        private readonly ApplicationDBContext _context = context;

        public async Task<Result<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var IsRoleIsExist = await _roleManager.FindByNameAsync(request.RoleName);
            if (IsRoleIsExist!=null)
                return Result.Failure<string>(AuthorizationErrors.RoleAlreadyExists);
            var role = new ApplicationRole
            {
                Name = request.RoleName,
                ConcurrencyStamp=Guid.NewGuid().ToString()
                
            };
            var allowedPermissions = Permissions.GetAllPermissions();
            if (request.Permission.Except(allowedPermissions).Any())
                return Result.Failure<string>(AuthorizationErrors.InvalidPermission);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                var permission = request.Permission.Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    RoleId = role.Id,
                    ClaimValue = x

                });
                await _context.AddRangeAsync(permission);
                await _context.SaveChangesAsync();
                return Result.Success("Role added successfully.");
            }
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
        }

        public async Task<Result<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            //check to try edit othor role name
            var RoleIsExist = await _context.Roles.AnyAsync(x => x.Name == request.RoleName && x.Id != request.Id);
            if(RoleIsExist)
                return Result.Failure<string>(AuthorizationErrors.RoleAlreadyExists);

            //check if role is found
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
                return Result.Failure<string>(AuthorizationErrors.RoleNotFound);
            //update role
            role.Name = request.RoleName;
            var result=await _roleManager.UpdateAsync(role);

            //update permission remove or add permission
            if (result.Succeeded)
            {
                var currentPermission = await _context.RoleClaims.Where(x => x.RoleId == request.Id && x.ClaimType == Permissions.Type)
                                                                .Select(x => x.ClaimValue)
                                                                .ToListAsync();
                var newPermissions = request.Permission.Except(currentPermission).Select(x=> new IdentityRoleClaim<string>
                {
                    RoleId = request.Id,
                    ClaimType = Permissions.Type,
                    ClaimValue=x
                });
                var removePermisions = currentPermission.Except(request.Permission);
                await _context.RoleClaims.Where(x=>x.RoleId==role.Id && removePermisions.Contains(x.ClaimValue))
                                         .ExecuteDeleteAsync();
                await _context.AddRangeAsync(newPermissions);
                await _context.SaveChangesAsync();
                return Result.Success("Role Updated successfully.");
            }
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));

        }

        public async Task<Result<bool>> Handle(ToggleStatusCommand request, CancellationToken cancellationToken)
        {
           var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null) 
                return Result.Failure<bool>(AuthorizationErrors.RoleNotFound);
            role.IsDelete=!role.IsDelete;
            await _roleManager.UpdateAsync(role);
            return Result.Success(true);
            
        }
    }
}
