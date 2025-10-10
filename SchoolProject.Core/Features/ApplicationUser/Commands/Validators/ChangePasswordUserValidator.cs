using FluentValidation;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class ChangePasswordUserValidator:AbstractValidator<ChangePasswordUserCommand>
    {
        public ChangePasswordUserValidator() {

            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("User Id is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Current password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.")
                .MinimumLength(6).WithMessage("New password must be at least 6 characters long.")
                .NotEqual(x => x.Password).WithMessage("New password cannot be the same as the current password.");

            RuleFor(x => x.NewPasswordConfirm)
                .NotEmpty().WithMessage("Password confirmation is required.")
                .Equal(x => x.NewPassword).WithMessage("Password confirmation does not match the new password.");
        }
    }
}
