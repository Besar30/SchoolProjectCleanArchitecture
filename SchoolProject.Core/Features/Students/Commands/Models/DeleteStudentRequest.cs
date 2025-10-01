using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentRequest:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public DeleteStudentRequest(int id)
        {
            Id= id;
        }
    }
}
