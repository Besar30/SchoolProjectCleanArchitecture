using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authrization.Commands.Models;
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
    public class AuthorizationCommandHandler(IAuthrizationServices authorizationService): IRequestHandler<AddRoleCommand, Result<string>>
    {
        private readonly IAuthrizationServices _authorizationService = authorizationService;

        public async Task<Result<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var IsRoleIsExist = await _authorizationService.IsRoleIsExist(request.RoleName);
            if (IsRoleIsExist)
                return Result.Failure<string>(AuthorizationErrors.RoleAlreadyExists);
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result)
                return Result.Success("Role added successfully.");

            return Result.Failure<string>(AuthorizationErrors.FailedToAddRole);
        }
    }
}
