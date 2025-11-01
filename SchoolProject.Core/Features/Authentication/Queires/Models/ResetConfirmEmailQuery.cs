using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queires.Models
{
    public class ResetConfirmEmailQuery:IRequest<Result<string>>
    {
        public string Email { get; set; }
    }
}
