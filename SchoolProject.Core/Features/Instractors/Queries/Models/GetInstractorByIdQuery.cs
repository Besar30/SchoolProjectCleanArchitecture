using MediatR;
using MimeKit.Tnef;
using SchoolProject.Core.Features.Instractors.Queries.Responses;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Queries.Models
{
    public class GetInstractorByIdQuery:IRequest<Result<GetInstractorByIdResponse>>
    {
        public int Id { get; set; }
        public GetInstractorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
