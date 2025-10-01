using MediatR;
using SchoolProject.Core.Features.Students.Queires.Response;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queires.Models
{
    public class GetStudentByIdQuery:IRequest<Result<StudentResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id= id;
        }
       public int Id { get; set; }
    }
}
