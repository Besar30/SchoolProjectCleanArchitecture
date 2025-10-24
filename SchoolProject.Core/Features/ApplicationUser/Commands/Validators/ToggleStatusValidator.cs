using FluentValidation;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class ToggleStatusValidator:AbstractValidator<ToggleStatusCommand>
    {
        public ToggleStatusValidator() {
            RuleFor(x => x.Id)
                 .NotEmpty()
                 .NotNull();

        }
    }
}
