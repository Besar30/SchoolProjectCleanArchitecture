using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
namespace SchoolProject.Core.Features.Subjects.Commands.Validator
{
    public class AddSubjectValidator:AbstractValidator<AddSubjectRequestCommand>
    {
        public AddSubjectValidator()
        {
            RuleFor(x=>x.SubjectNameAr).NotNull().NotEmpty();
            RuleFor(x=>x.SubjectNameEn).NotNull().NotEmpty();
            RuleFor(x => x.Period)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Period must be greater than 0.");
        }
    }
}
