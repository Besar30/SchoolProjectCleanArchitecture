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
    public class GetRoleDetailsByIdQuery:IRequest<Result<GetRoleDetailsByIdResponse>>
    {
        public string Id { get; set; }
        public GetRoleDetailsByIdQuery(string id) { 
            
            Id=id;
        }
    }
}
