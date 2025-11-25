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
    public class GetAllInstractorQuery:IRequest<Result<List<GetAllInstractorResponse>>>
    {

    }
}
