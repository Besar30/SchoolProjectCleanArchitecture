using FluentValidation;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Commands.Validator
{
    public class AddInstractorValidator:AbstractValidator<AddInstractorCommand>
    {
        public AddInstractorValidator() {

            RuleFor(x => x.ENameAr).NotNull()
             .NotEmpty().WithMessage("Arabic name is required.")
             .Matches(@"^[\u0600-\u06FF\s]+$").WithMessage("Arabic name must contain only Arabic letters.");

            RuleFor(x => x.ENameEn)
                .NotEmpty().WithMessage("English name is required.")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("English name must contain only English letters.");


            RuleFor(x => x.Address).NotNull()
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

            RuleFor(x => x.Position).NotNull()
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(50).WithMessage("Position must not exceed 50 characters.");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than zero.");

            RuleFor(x => x.Image)
                .Must(IsValidImage)
                .WithMessage("Image must be a valid file type: PNG, JPG, or JPEG.")
                .When(x => x.Image != null);
                
        }
        private bool IsValidImage(IFormFile? Image)
        {
            if (Image==null)
                return true;
            var allowedExtension = new[] { ".jpg", ".jpeg", ".png" };
            var ExtentionImage = Path.GetExtension(Image.FileName).ToLower();
            return allowedExtension.Contains(ExtentionImage);
        }
    }
}
