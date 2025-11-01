using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class ResetNewPasswordValidator:AbstractValidator<ResetNewPasswordCommand>
    {
        public ResetNewPasswordValidator() {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");
        }
    }
}
