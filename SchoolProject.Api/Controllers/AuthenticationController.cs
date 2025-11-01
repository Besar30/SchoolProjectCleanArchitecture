using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queires.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisrtationAsync([FromBody] RegistrationCommand command)
        {
            var result= await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : result.ToProblem();

        }

        [HttpPost("")]
        public async Task<IActionResult> SignIn([FromBody] SigninCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : result.ToProblem();
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
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] ConfirmEmailCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("ResetConfirmEmail")]
        public async Task<IActionResult> ResetConfirmEmail([FromQuery]  ResetConfirmEmailQuery query)
        {
            var resutl = await _mediator.Send(query);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("ResetPaswword")]
        public async Task<IActionResult> ResetPaswword([FromQuery] ResetPasswordCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("ConfirmResetPaswword")]
        public async Task<IActionResult> ConfirmResetPaswword([FromQuery] ConfirmCodeRestPasswordCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
        [HttpPost("GetNewPaswword")]
        public async Task<IActionResult> GetNewPaswword([FromQuery] ResetNewPasswordCommand command)
        {
            var resutl = await _mediator.Send(command);
            return resutl.IsSuccess ? Ok(resutl) : resutl.ToProblem();
        }
    }
}
