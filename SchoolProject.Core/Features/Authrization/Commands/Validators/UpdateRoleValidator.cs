using FluentValidation;
using SchoolProject.Core.Features.Authrization.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Commands.Validators
{
    public class UpdateRoleValidator:AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidator() {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.RoleName)
          .NotEmpty().WithMessage("Role name cannot be empty.");
            RuleFor(x => x.Permission)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Permission)
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("You Cannot add duplicated Permissions for the same role")
                .When(x => x.Permission != null);
        }
    }
}
