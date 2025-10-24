using FluentValidation;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class EditUserValidator:AbstractValidator<EditUserCommand>
    {
        public EditUserValidator() {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
                RuleFor(x => x.Email)
                  .NotEmpty().WithMessage("Email is required.")
                  .EmailAddress().WithMessage("Invalid email format.");

                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("Username is required.")
                    .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("Last name is required.")
                    .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(x => x.Roles)
             .NotEmpty()
             .NotNull();
            RuleFor(x => x.Roles)
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("You Cannot add dublicated Role.")
                .When(x => x.Roles != null);

        }
    }
}
