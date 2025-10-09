using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Queires.Results;
using SchoolProject.Core.pagination;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queires.Models
{
    public class GetUserPaginationQuery:IRequest<Result<PaginatedList<GetUserPaginationResponse>>>
    {
        public RequestFilters RequestFilters { get; set; }

    }
}
