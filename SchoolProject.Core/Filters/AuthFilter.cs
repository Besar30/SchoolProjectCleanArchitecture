using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.AuthServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Filters
{
    public class AuthFilter (ICurrentUserServices currentUserServices,UserManager<User> userManager): IAsyncActionFilter
    {
        private readonly ICurrentUserServices _currentUserServices = currentUserServices;
        private readonly UserManager<User> _userManager = userManager;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var roles=await _currentUserServices.GetCurrentUserRolesAsync();
                if (roles.All(x =>( x != DefaultRoles.Member))) {
                    context.Result = new ObjectResult("Forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
