using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System.Security.Claims;
using System.Xml.Linq;
namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler(UserManager<User> userManager, IMapper mapper
                                    ,RoleManager<ApplicationRole> roleManager
                                    ,ApplicationDBContext context
                                    ,IHttpContextAccessor httpContextAccessor):IRequestHandler<AddUserCommand, Result<string>>,
                                                                               IRequestHandler<EditUserCommand,Result<string>>,
                                                                               IRequestHandler<DeleteUserCommand,Result<string>>,
                                                                               IRequestHandler<ChangePasswordUserCommand,Result<string>>,
                                                                               IRequestHandler<ToggleStatusCommand,Result>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
        private readonly ApplicationDBContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<Result<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //check email is exist
            var Emailuser = await _userManager.FindByEmailAsync(request.Email);
            if (Emailuser != null)
                return Result.Failure<string>(UserErrors.EmailAlreadyExists);
            //check username is exist
            var UserNameuser= await _userManager.FindByNameAsync(request.UserName);
            if(UserNameuser != null)
                return Result.Failure<string>(UserErrors.UserNameAlreadyExists);
            //check role is true 
            var allowedRoles = await _roleManager.Roles.Where( x=>!x.IsDelete).ToListAsync();
            if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any()){
                return Result.Failure<string>(AuthorizationErrors.InvalidRoles);
            }
            //mapping
            var UserIdentity = _mapper.Map<User>(request);
            //create
            var result = await _userManager.CreateAsync(UserIdentity, request.Password);
            //faild
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(UserIdentity,request.Roles);
                //secsess
                return Result.Success($"User '{UserIdentity.UserName}' created successfully.");
            }
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
        }

        public async Task<Result<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //check email is exist
            var Emailuser = await _context.Users.AnyAsync(x => x.Email == request.Email && x.Id != request.Id);
            if (Emailuser)
                return Result.Failure<string>(UserErrors.EmailAlreadyExists);
            //check username is exist
            var UserNameuser = await _context.Users.AnyAsync(x => x.UserName == request.UserName && x.Id != request.Id);
            if (UserNameuser)
                return Result.Failure<string>(UserErrors.UserNameAlreadyExists);
            //check role is true 
            var allowedRoles = await _roleManager.Roles.Where(x => !x.IsDefualt && !x.IsDelete).ToListAsync();
            if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
                return Result.Failure<string>(AuthorizationErrors.InvalidRoles);
            
            //mapping
            var user= await _userManager.FindByIdAsync(request.Id);
            if(user==null)
                return Result.Failure<string>(UserErrors.UserNotFound);

             _mapper.Map(request,user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _context.UserRoles.Where(x => x.UserId == request.Id)
                               .ExecuteDeleteAsync();
                await _userManager.AddToRolesAsync(user, request.Roles);
                return Result.Success("User updated successfully");
            }
            //faild
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));

        }

        public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return Result.Failure<string>(UserErrors.UserNotFound);
           

            var Roles = await _userManager.GetRolesAsync(user);
            if (Roles.Contains("Admin"))
            {
                //check if admin remove him self
                var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (currentUserId == request.Id)
                    return Result.Failure<string>(UserErrors.SelfDeleteNotAllowed);
                //check is the last admin
                var adminsCount = (await _userManager.GetUsersInRoleAsync("Admin")).Count;
                if (adminsCount <= 1)
                    return Result.Failure<string>(UserErrors.CanNotDeleteAdmin);
                //if not last admin disable admin just
                    user.IsDisabled = true;
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                    return Result.Failure<string>(
                        new Error(updateResult.Errors.First().Code, updateResult.Errors.First().Description, StatusCodes.Status409Conflict)
                    );
                return Result.Success("Admins cannot be deleted. Admin has been disabled instead.");
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
            return Result.Success("User deleted successfully.");
        }

        public async Task<Result<string>> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByIdAsync(request.Id);
            var result = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
            if(!result.Succeeded)
                return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
            return Result.Success("Password changed successfully");
        }

        public async Task<Result> Handle(ToggleStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return Result.Failure(UserErrors.UserNotFound);
            user.IsDisabled=!user.IsDisabled;
            var result=await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Result.Success();
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status400BadRequest));
        }
    }
}
