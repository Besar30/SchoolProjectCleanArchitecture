using MediatR;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ConfirmCodeRestPasswordCommand:IRequest<Result<string>>
    {
        public string Email { get; set; }
       public string Code { get; set; }
    }
}
