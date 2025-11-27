using MediatR;
using SchoolProject.Core.Features.Departments.Queires.Responses;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queires.Models
{
    public class GetAllDepartmentQuery:IRequest<Result<List<GetDepartmentByIdResponse>>>
    {

    }
}
