using MediatR;
using SchoolProject.Core.Features.Instractors.Queries.Responses;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Queries.Models
{
    public class GetInstractorByNameQuery:IRequest<Result<GetInstractorByIdResponse>>
    {
        public string Name { get; set; }
        public GetInstractorByNameQuery(string name)
        {
            Name = name;
        }
    }
}
