using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class SigninValidator:AbstractValidator<SigninCommand>
    {
        public SigninValidator() {
            RuleFor(x => x.Email)
                .EmailAddress()
             .NotEmpty().WithMessage("Email is required")
             .NotNull().WithMessage("Email is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password is required");
        }
    }
}
