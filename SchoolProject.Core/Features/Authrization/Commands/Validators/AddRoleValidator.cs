using FluentValidation;
using SchoolProject.Core.Features.Authrization.Commands.Models;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Commands.Validators
{
    public class AddRoleValidator :AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthrizationServices _authrizationServices;
        public AddRoleValidator(IAuthrizationServices authrizationServices)
        {
            _authrizationServices = authrizationServices;

            RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Role name cannot be empty.");
            
        }
    }
}
