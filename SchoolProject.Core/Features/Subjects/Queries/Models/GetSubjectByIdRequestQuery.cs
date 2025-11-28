using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.response;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdRequestQuery:IRequest<Result<GetSubjectByIdResponse>>
    {
        public int Id { get; set; }
        public GetSubjectByIdRequestQuery(int id)
        {
            Id=id;
        }
    }
}
