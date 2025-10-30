using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Emails.Commands.Handler
{
    public class EmailCommandHandler (IEmailService emailService): IRequestHandler<SendEmailCommand, Result<string>>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task<Result<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendMassege(request.Email, request.Massege);
            if (result.IsSuccess)
                return Result.Success("Massege sented.");
            return Result.Failure<string>(new Error("","",StatusCodes.Status400BadRequest));
        }
    }
}
