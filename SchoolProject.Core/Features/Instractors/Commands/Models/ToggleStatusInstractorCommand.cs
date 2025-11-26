using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Commands.Models
{
    public class ToggleStatusInstractorCommand:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public ToggleStatusInstractorCommand(int id)
        {
            Id = id;
        }
    }
}
