using Microsoft.AspNetCore.Http;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Errors
{
    public static class AuthenticationErrors
    {
        public static readonly Error TokenNotValid = new Error(
                                            "Token.Invalid",
                                            "Refresh token is not valid or expired",
                                            StatusCodes.Status401Unauthorized);
        public static Error RefreshTokenNotFound = new Error(
                                            "REFRESH_TOKEN_NOT_FOUND",
                                            "Refresh token not found or inactive",
                                            StatusCodes.Status401Unauthorized);
        public static readonly Error EmailAlreadyExists =
        new("User.EmailAlreadyExists", "Email already exists", StatusCodes.Status400BadRequest);
        public static readonly Error UserNameAlreadyExists =
         new("User.UserNameAlreadyExists", " UserName already exists", StatusCodes.Status400BadRequest);
        public static readonly Error EmailUserNotConfirmed = new(
                                                      "EmailUser.NotConfirmed",
                                                      "Email User Not Confirmed.",
                                                      StatusCodes.Status400BadRequest);
        public static readonly Error ConfirmEmail = new Error("Email.SendFailed",
                          "User created but failed to send confirmation email. Please try again.",
                          StatusCodes.Status500InternalServerError);
        public static readonly Error InvalidEmailConfirmationToken = new Error(
                                                                    "Auth.InvalidEmailConfirmationToken",
                                                                    "The email confirmation token is invalid or expired.",
                                                                    StatusCodes.Status400BadRequest);
    }
}
