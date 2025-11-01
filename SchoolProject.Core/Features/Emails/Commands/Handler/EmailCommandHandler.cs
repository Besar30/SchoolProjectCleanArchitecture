using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Emails.Commands.Handler
{
    public class EmailCommandHandler (IEmailService emailService,UserManager<User> userManager): IRequestHandler<SendEmailCommand, Result<string>>
    {
        private readonly IEmailService _emailService = emailService;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<Result<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var EmailIsExist= await _userManager.FindByEmailAsync(request.Email);
            if (EmailIsExist == null)
                return Result.Failure<string>(UserErrors.UserNotFound);
            var result = await _emailService.SendMassege(request.Email, request.Massege,null);
            if (result.IsSuccess)
                return Result.Success("Massege sented.");
            return Result.Failure<string>(
                           new Error("Email.Error",
                           "Failed to send email",
                           StatusCodes.Status400BadRequest));
        }
    }
}
