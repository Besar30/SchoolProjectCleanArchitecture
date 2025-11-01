using FluentValidation;
using SchoolProject.Core.Features.Authentication.Queires.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queires.validator
{
    public class ResetConfirmEmailValidator:AbstractValidator<ResetConfirmEmailQuery>
    {
        public ResetConfirmEmailValidator() {
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }
    }
}
