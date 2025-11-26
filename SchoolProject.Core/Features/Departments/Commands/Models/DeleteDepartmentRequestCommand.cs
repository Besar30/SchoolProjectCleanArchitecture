using MediatR;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentRequestCommand:IRequest<Result<string>>
    {
        public int Id { get; set; }
        public DeleteDepartmentRequestCommand(int id)
        {
            Id = id;
        }
    }
}
