using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queires.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.pagination;
using SchoolProject.Shared.Absractions;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController (IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("")]
        public async Task<IActionResult> GetUser([FromQuery] RequestFilters filters)
        {
            var response = await _mediator.Send(new GetUserPaginationQuery
            {
                RequestFilters = filters
            });
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser([FromRoute] string Id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(Id));
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : response.ToProblem();
        }

        [HttpPut("")]
        public async Task<IActionResult> EditUserAsync([FromBody] EditUserCommand request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpDelete("{Id}")]
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
       
    }
}
