using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.Authrization.Queries.Models;
using SchoolProject.Core.Features.Authrization.Queries.Results;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Queries.Handlers
{
    public class AuthorizationQueryHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper) : IRequestHandler<GetAllRoleQuery, Result<List<GetAllRoleResponse>>>,
                                                                                              IRequestHandler<GetRoleDetailsByIdQuery,Result<GetRoleDetailsByIdResponse>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List< GetAllRoleResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            //get roles
            var Roles= await _roleManager.Roles.Where(x=>!x.IsDefualt&&(!x.IsDelete||(request.IncludeDeleted.HasValue && request.IncludeDeleted.Value))).ToListAsync();
            if (Roles == null || Roles.Count == 0)
                return Result.Failure<List<GetAllRoleResponse>>(AuthorizationErrors.NoRolesFound);
            //mapping
            var RoleResponse = _mapper.Map<List<GetAllRoleResponse>> (Roles);
            //seucsse
            return Result.Success(RoleResponse);
        }

        public async Task<Result<GetRoleDetailsByIdResponse>> Handle(GetRoleDetailsByIdQuery request, CancellationToken cancellationToken)
        {
           //check if role is found
           var role= await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
                return Result.Failure<GetRoleDetailsByIdResponse>(AuthorizationErrors.RoleNotFound);
            var Permissions = await _roleManager.GetClaimsAsync(role);
            var response = new GetRoleDetailsByIdResponse
            {
                Id = role.Id,
                Name = role.Name,
                IsDelete = role.IsDelete,
                Permissions = Permissions.Select(x => x.Value)
            };
            return Result.Success(response);
        }
    }
}
