using MediatR;
using SchoolProject.Core.Features.Authrization.Queries.Results;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Queries.Models
{
    public class GetAllRoleQuery:IRequest<Result<List<GetAllRoleResponse>>>
    {
        public bool? IncludeDeleted { get; set; }
        public GetAllRoleQuery(bool? includeDeleted)
        {
            IncludeDeleted = includeDeleted;
        }
    }
}
