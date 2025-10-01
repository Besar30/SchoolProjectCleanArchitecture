using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentRequestValidator:AbstractValidator<EditStudentRequest>
    {
        public EditStudentRequestValidator() {
            RuleFor(x => x.NameAr)
                  .NotEmpty().WithMessage("Name is required.")
                  .Length(3, 150);
            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage("Name is required.")
                 .Length(3, 150);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(3, 150);

            RuleFor(x => x.phone)
                .Matches(@"^\d{11}$").WithMessage("Phone must be 11 digits.");
        }
    }
}
