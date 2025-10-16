using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RevokeRefreshTokenCommand:IRequest<Result<bool>>
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
