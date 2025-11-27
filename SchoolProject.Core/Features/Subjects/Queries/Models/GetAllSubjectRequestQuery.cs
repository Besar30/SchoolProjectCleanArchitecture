using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.response;
using SchoolProject.Core.pagination;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetAllSubjectRequestQuery:IRequest<Result<PaginatedList<GetAllSubjectResponse>>>
    {
        public RequestFilters _requestFilters { get; set; }
        public GetAllSubjectRequestQuery(RequestFilters requestFilters)
        {
            _requestFilters = requestFilters;
        }
    }
}
