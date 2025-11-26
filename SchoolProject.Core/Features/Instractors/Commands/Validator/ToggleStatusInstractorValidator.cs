using FluentValidation;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Commands.Validator
{
    public  class ToggleStatusInstractorValidator:AbstractValidator<ToggleStatusInstractorCommand>
    {
        public ToggleStatusInstractorValidator() {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
