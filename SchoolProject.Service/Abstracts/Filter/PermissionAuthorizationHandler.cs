using Microsoft.AspNetCore.Authorization;
using SchoolProject.Api.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts.Filter
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.Identity is not { IsAuthenticated: true } ||
                 !context.User.Claims.Any(x => x.Value == requirement.Permission && x.Type == Permissions.Type))
                return;

            context.Succeed(requirement);
            return;
        }

    }
}
