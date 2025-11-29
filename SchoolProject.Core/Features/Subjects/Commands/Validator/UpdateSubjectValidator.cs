using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Validator
{
    public class UpdateSubjectValidator:AbstractValidator<UpdateSubjectRequestCommand>
    {
        public UpdateSubjectValidator() {
            RuleFor(x => x.SubID)
                               .GreaterThan(0)
                               .WithMessage("Subject ID must be greater than 0");
            RuleFor(x => x.SubjectNameAr)
                                        .NotEmpty().WithMessage("Subject Arabic name is required")
                                        .Length(3, 100).WithMessage("Subject Arabic name must be between 3 and 100 characters");
            RuleFor(x => x.SubjectNameEn)
                                         .MaximumLength(100).WithMessage("Subject English name can't exceed 100 characters");

            RuleFor(x => x.Period)
                                 .GreaterThan(0).When(x => x.Period.HasValue);
        }
    }
}
