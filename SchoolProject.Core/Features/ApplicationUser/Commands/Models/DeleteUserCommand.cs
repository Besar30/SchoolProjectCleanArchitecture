using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand:IRequest<Result<string>>
    {
        public DeleteUserCommand(string id) {
            Id = id;
        }
        public string Id { get; set; }

    }
}
