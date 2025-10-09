using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class UserErrors
    {
        public static readonly Error EmailAlreadyExists =
            new("User.EmailAlreadyExists", "Email already exists", StatusCodes.Status409Conflict);
        public static readonly Error UserNameAlreadyExists =
           new("User.UserNameAlreadyExists", " UserName already exists", StatusCodes.Status409Conflict);

        public static readonly Error UserNotFound =
        new("User.UserNotFound", " User Not Found", StatusCodes.Status404NotFound);
    }
}
