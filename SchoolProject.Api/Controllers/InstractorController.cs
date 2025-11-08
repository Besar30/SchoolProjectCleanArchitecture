using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class InstractorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Add-Insturctor")]
        [HasPermission(Permissions.AddInstructor)]
        public async Task<IActionResult> AddInstractorAsync([FromForm] AddInstractorCommand command)
        {
            var result= await _mediator.Send(command);
            return result.IsSuccess?
                              Ok(result) : result.ToProblem();
        }
    }
}
