using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Commands.Models
{
    public class UpdateRoleCommand:IRequest<Result<string>>
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public IList<string> Permission { get; set; }

    }
}
