using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Authrization.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        public async Task<IActionResult> AddStudentAsync([FromForm] AddRoleCommand request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
    }
}
