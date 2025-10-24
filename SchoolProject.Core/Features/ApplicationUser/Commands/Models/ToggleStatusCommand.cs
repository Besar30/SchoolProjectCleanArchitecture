using MediatR;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class ToggleStatusCommand:IRequest<Result>
    {
        public string Id { get; set; }
        public ToggleStatusCommand(string id) { 
            Id = id;
        }

    }
}
