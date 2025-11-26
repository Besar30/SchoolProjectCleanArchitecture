using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class ToggleStatusStudentCommand:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public ToggleStatusStudentCommand(int id)
        {
            Id=id;
        }
    }
}
