using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectRequestCommand:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public DeleteSubjectRequestCommand(int id) { 
            Id = id; 
        }
    }
}
