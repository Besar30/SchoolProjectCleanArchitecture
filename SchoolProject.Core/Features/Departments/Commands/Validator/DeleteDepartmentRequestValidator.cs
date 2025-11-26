using FluentValidation;
using SchoolProject.Core.Features.Departments.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Validator
{
    public class DeleteDepartmentRequestValidator:AbstractValidator<DeleteDepartmentRequestCommand>
    {
        public DeleteDepartmentRequestValidator() {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
