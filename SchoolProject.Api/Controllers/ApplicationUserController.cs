using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queires.Models;
using SchoolProject.Core.pagination;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class ApplicationUserController (IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("")]
        [HasPermission(Permissions.GetUsers)]
        public async Task<IActionResult> GetUser([FromQuery] RequestFilters filters)
        {
            var response = await _mediator.Send(new GetUserPaginationQuery
            {
                RequestFilters = filters
            });
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpGet("{Id}")]
        [HasPermission(Permissions.GetUsers)]
        public async Task<IActionResult> GetUser([FromRoute] string Id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(Id));
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpPost("")]
        [HasPermission(Permissions.AddUsers)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpPut("")]
        [HasPermission(Permissions.UpdateUsers)]
        public async Task<IActionResult> EditUserAsync([FromBody] EditUserCommand request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpDelete("{Id}")]
        [HasPermission(Permissions.DeleteUsers)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string Id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(Id));
            return result.IsSuccess ?
               Ok(result) : result.ToProblem();
        }
        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePasswodAsync([FromBody] ChangePasswordUserCommand request)
        {
            var result= await _mediator.Send(request);
            return result.IsSuccess ?
              Ok(result) : result.ToProblem();
        }
        [HttpPut("ToggleStatues/{Id}")]
        public async Task<IActionResult> ToggleStatues([FromRoute] string Id)
        {
            var result= await _mediator.Send(new ToggleStatusCommand(Id));
            return result.IsSuccess ?
             Ok(result) : result.ToProblem();
        }

    }
}