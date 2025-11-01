using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ResetNewPasswordCommand:IRequest<Result<string>>
    {
        public string Email {  get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
