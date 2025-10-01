using MediatR;
using SchoolProject.Core.Features.Students.Queires.Response;
using SchoolProject.Core.pagination;
using SchoolProject.Data.Entites;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queires.Models
{
    public class GetStudentListQuery : IRequest<Result<PaginatedList<StudentResponse>>>
    {
        public RequestFilters RequestFilters { get; set; }
    }
}
