using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class ConfirmCodeRestPasswordValidator:AbstractValidator<ConfirmCodeRestPasswordCommand>
    {
        public ConfirmCodeRestPasswordValidator() {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x=>x.Code).NotNull().NotEmpty();
        }
    }
}
