using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authrization.Commands.Models
{
    public class ToggleStatusCommand:IRequest<Result<bool>>
    {
        public string Id { get; set; }
        public ToggleStatusCommand(string id)
        {
            Id = id;
        }
    }
}
