using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class AuthorizationErrors
    {
        public static readonly Error FailedToAddRole = new Error(
        "Role.FailedToAdd",
        "Failed to add the role.",
        StatusCodes.Status400BadRequest);
        public static readonly Error RoleAlreadyExists = new Error(
        "Role.AlreadyExists",
        "The role already exists.",
        StatusCodes.Status409Conflict);
    }
}
