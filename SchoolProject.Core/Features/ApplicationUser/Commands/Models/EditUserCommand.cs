using MediatR;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class EditUserCommand:IRequest<Result<string>>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string>Roles { get; set; }
    }
}
