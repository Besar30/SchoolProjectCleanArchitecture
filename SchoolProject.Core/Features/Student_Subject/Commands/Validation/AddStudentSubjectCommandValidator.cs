using FluentValidation;
using SchoolProject.Core.Features.Student_Subject.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student_Subject.Commands.Validation
{
    public class AddStudentSubjectCommandValidator:AbstractValidator<AddStudentSubjectCommand>
    {
        public AddStudentSubjectCommandValidator() {
            RuleFor(x => x.StudentID).NotNull().NotEmpty();
            RuleFor(x => x.SubjectID).NotNull().NotEmpty();
        }
    }
}
