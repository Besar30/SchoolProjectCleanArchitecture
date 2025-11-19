using FluentValidation;
using SchoolProject.Core.Features.Departments.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Validator
{
    public class UpdateDepartmentRequestValidator:AbstractValidator<UpdateDepartmentRequestCommand>
    {
        public UpdateDepartmentRequestValidator() {
            RuleFor(x=>x.DID).NotNull().NotEmpty();
            RuleFor(x => x.DNameAr).NotNull()
              .NotEmpty().WithMessage("Arabic Department Name is required");

            RuleFor(x => x.DNameEn).NotNull()
                .NotEmpty().WithMessage("English Department Name is required");
        }
    }
}
