using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Queires.Results;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queires.Models
{
    public class GetUserByIdQuery:IRequest<Result<GetUserByIdResponse>>
    {
        public GetUserByIdQuery(string id) {
            Id= id;
        }
        public string Id { get; set; }
    }
}
