using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        public async Task<IActionResult> SignIn([FromBody] SigninCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("Refresh-Token")]
        public async Task<IActionResult> GetRefreshToken([FromBody] GetRefreshTokenCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("Revoke-Refresh-Token")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RevokeRefreshTokenCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
    }
}
