using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class ChangePasswordUserCommand:IRequest<Result<string>>
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }

    }
}
