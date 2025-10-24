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

        public static readonly Error NoRolesFound = new Error(
       "Roles.Notfound.",
       "No roles found.",
       StatusCodes.Status404NotFound);
        public static readonly Error RoleNotFound = new Error(
      "Roles.Notfound.",
      "Role Not Found.",
      StatusCodes.Status404NotFound);
        public static readonly Error InvalidPermission = new(
     "Roles.InvalidPermission",
     "Invalid Permission.",
     StatusCodes.Status400BadRequest);
        public static readonly Error InvalidRoles = new(
     "Roles.InvalidRole",
     "Invalid Roles.",
     StatusCodes.Status400BadRequest);
    }
}
