using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentRequestValidator:AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage("Name is required.")
                 .Length(3,150);
            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage("Name is required.")
                 .Length(3, 150);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(3,150);

            RuleFor(x => x.phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\d{11}$").WithMessage("Phone must be 11 digits.");
            RuleFor(x => x.DID)
                .NotNull()
                .NotEmpty();

        }
    }
}
