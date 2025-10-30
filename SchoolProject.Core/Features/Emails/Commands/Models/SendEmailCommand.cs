using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommand:IRequest<Result<string>>
    {
        public string Email { get; set; }
        public string Massege { get; set; }
    }
}
