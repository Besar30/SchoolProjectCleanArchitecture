using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validator
{
    public class RevokeRefreshTokenValidator:AbstractValidator<RevokeRefreshTokenCommand>
    {
        public RevokeRefreshTokenValidator() {

            RuleFor(x => x.refreshToken).NotEmpty();
            RuleFor(x => x.token).NotEmpty();

        }
    }
}
