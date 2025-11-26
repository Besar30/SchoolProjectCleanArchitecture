using FluentValidation;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class ToggleStatusStudentValidator:AbstractValidator<ToggleStatusStudentCommand>
    {
        public ToggleStatusStudentValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
