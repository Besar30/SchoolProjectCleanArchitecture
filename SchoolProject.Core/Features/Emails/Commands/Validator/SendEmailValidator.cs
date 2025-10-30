using FluentValidation;
using SchoolProject.Core.Features.Emails.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Emails.Commands.Validator
{
    public class SendEmailValidator:AbstractValidator<SendEmailCommand>
    {
        public SendEmailValidator() {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x=>x.Massege).NotNull().NotEmpty();
        }
    }
}
