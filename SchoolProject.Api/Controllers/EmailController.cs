using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Infrastructure.Abstracts.Const;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]

    public class EmailController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Send-Massege-To-Email")]
        public async Task<IActionResult> SendEmailAsync([FromQuery]SendEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
    }
}
