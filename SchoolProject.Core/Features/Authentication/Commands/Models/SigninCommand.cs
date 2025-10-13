using MediatR;
using SchoolProject.Core.Features.Authentication.Commands.Results;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SigninCommand:IRequest<Result<SigninResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
