using FluentValidation;
using SchoolProject.Core.Features.Departments.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Validator
{
    public class AddDepartmentRequestValidator:AbstractValidator<AddDepartmentRequestCommand>
    {
        public AddDepartmentRequestValidator() {

            RuleFor(x => x.DNameAr).NotNull()
                .NotEmpty().WithMessage("Arabic Department Name is required");

            RuleFor(x => x.DNameEn).NotNull()
                .NotEmpty().WithMessage("English Department Name is required");
        }
    }
}
