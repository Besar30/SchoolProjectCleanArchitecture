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
        public static readonly Error InvalidCredentials = new(
                 "User.InvalidCredentials",
                 "Invalid email or password",
                 StatusCodes.Status400BadRequest);
        public static readonly Error UserIsDisabled = new(
                                                        "User.Disabled",
                                                        "This user account is disabled.",
                                                        StatusCodes.Status403Forbidden);
        public static readonly Error CanNotDeleteAdmin = new(
                                                     "CanNotDeleteAdmin",
                                                     "You cannot delete the last admin in the system.",
                                                     StatusCodes.Status403Forbidden);
        public static readonly Error SelfDeleteNotAllowed = new Error("SelfDeleteNotAllowed",
                                                                    "Admins cannot delete their own account.",
                                                                    StatusCodes.Status403Forbidden);

        public static readonly Error EmailAlreadyConfirmed = new(
                                                                "EmailAlreadyConfirmed",
                                                                "This email is already confirmed.",
                                                                StatusCodes.Status400BadRequest);
        public static readonly Error InvalidResetCode = new Error(
                                                                "Auth.InvalidResetCode",
                                                                "The reset password code is invalid. Please check the code and try again.",
                                                                StatusCodes.Status400BadRequest);
    }
}
