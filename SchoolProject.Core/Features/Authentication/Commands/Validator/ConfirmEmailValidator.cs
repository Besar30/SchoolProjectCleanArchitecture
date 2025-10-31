using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class ConfirmEmailValidator:AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailValidator() {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x=>x.code).NotNull().NotEmpty();
        }
    }
}
