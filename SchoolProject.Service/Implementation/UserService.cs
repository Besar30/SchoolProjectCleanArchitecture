using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class UserService(UserManager<User> userManager,IHttpContextAccessor httpContextAccessor,IUrlHelper urlHelper,IEmailService emailService) 
                                                                        : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IUrlHelper _urlHelper = urlHelper;
        private readonly IEmailService _emailService = emailService;

        public async Task<Result> ResetConfirmEmailService(string email)
        {
         var UserIsExist= await _userManager.FindByEmailAsync(email);
            if (UserIsExist == null)
                return Result.Failure(UserErrors.UserNotFound);
            if (UserIsExist.EmailConfirmed)
                return Result.Failure(UserErrors.EmailAlreadyConfirmed);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(UserIsExist);
            var RequestAccessor = _httpContextAccessor.HttpContext.Request;
            var ReturnUrl =RequestAccessor.Scheme+"://"+RequestAccessor.Host+
                                    _urlHelper.Action("ConfirmEmail", "Authentication", new { UserId = UserIsExist.Id, code = code });
            var resultOfConfirmEmail = await _emailService.SendMassege(email, ReturnUrl, "Reset Confirm your Email");
            if (!resultOfConfirmEmail.IsSuccess)
                return Result.Failure<string>(AuthenticationErrors.ConfirmEmail);
            return Result.Success();
        }
        public async Task<Result> ResetPasswordService(string email)
        {
            var UserIsExist = await _userManager.FindByEmailAsync(email);
            if (UserIsExist == null)
                return Result.Failure(UserErrors.UserNotFound);
            Random Generator = new Random();
            string randomNumber = Generator.Next(0, 1000000).ToString("D6");
            UserIsExist.Code = randomNumber;
            UserIsExist.CodeExpireAt = DateTime.UtcNow.AddMinutes(3);
            UserIsExist.CodeIsUsed = false;
            var result =await _userManager.UpdateAsync(UserIsExist);
            if(!result.Succeeded)
                return Result.Failure(new Error(result.Errors.First().Code, result.Errors.First().Description,StatusCodes.Status400BadRequest));
            var reason = "Code To Reset Password : ";
            var RandomNumberMessage = $"Your reset code is: {randomNumber}\nThis code is valid for 3 minutes.";
            var ResetCode = await _emailService.SendMassege(email, RandomNumberMessage, reason);
            if (ResetCode.IsSuccess)
                return Result.Success();
            return Result.Failure(ResetCode.error);
        }

        public async Task<Result> ResetPasswordConfirmationService(string email, string code)
        {
            //check if email is not exist
            var user = await _userManager.FindByEmailAsync(email);
            if(user==null)
                return Result.Failure(UserErrors.UserNotFound);
            //check if code is vaild not expire
            if (DateTime.UtcNow > user.CodeExpireAt)
                return Result.Failure<string>(AuthenticationErrors.ResetCodeExpired);
            //check if code is used already
            if (user.CodeIsUsed)
                return Result.Failure(AuthenticationErrors.ResetCodeAlreadyUsed);
            //check if code is correct
            if (user.Code != code)
                return Result.Failure(AuthenticationErrors.InvalidResetCode);
            user.CodeIsUsed = true;
            var result= await _userManager.UpdateAsync(user);
            if(result.Succeeded)
                return Result.Success();
            return Result.Failure(new Error(result.Errors.First().Code, result.Errors.First().Description, StatusCodes.Status400BadRequest));
        }

        public async Task<Result> ResetPasswordConfirmationConfirmationService(string email, string NewPassword, string ConfirmPassword)
        {
            //check if email is not exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Result.Failure(UserErrors.UserNotFound);
            if (NewPassword != ConfirmPassword)
                return Result.Failure(AuthenticationErrors.PasswordMismatch);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetResult = await _userManager.ResetPasswordAsync(user, token, NewPassword);
            if (!resetResult.Succeeded)
                return Result.Failure(new Error(resetResult.Errors.First().Code, resetResult.Errors.First().Description, StatusCodes.Status400BadRequest));
            return Result.Success();
        }
    }
}
