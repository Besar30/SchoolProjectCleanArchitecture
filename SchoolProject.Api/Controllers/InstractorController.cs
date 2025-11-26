using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Core.Features.Instractors.Queries.Models;
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


        [HttpGet("/Get-Instructor-By-Id/{Id}")]
        [HasPermission(Permissions.GetInstructors)]

        public async Task<IActionResult>GetInstractoByIdAsyc(int Id)
        {
            var result = await _mediator.Send(new GetInstractorByIdQuery(Id));
            return result.IsSuccess?
                Ok(result) : result.ToProblem();
        }

        [HttpGet("/Get-Instructor-By-Name/{Name}")]
        [HasPermission(Permissions.GetInstructors)]
        public async Task<IActionResult> GetInstractoByNameAsyc([FromRoute]string Name)
        {
            var result = await _mediator.Send(new GetInstractorByNameQuery(Name));
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }

        [HttpGet("/Get-All-Instructors")]
        [HasPermission(Permissions.GetInstructors)]
        public async Task<IActionResult> GetAllInstractors()
        {
            var result = await _mediator.Send(new GetAllInstractorQuery());
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }

        [HttpPost("Add-Insturctor")]
        [HasPermission(Permissions.AddInstructor)]
        public async Task<IActionResult> AddInstractorAsync([FromForm] AddInstractorCommand command)
        {
            var result= await _mediator.Send(command);
            return result.IsSuccess?
                              Ok(result) : result.ToProblem();
        }
        [HttpPut("Update-Insturctor")]
        [HasPermission(Permissions.UpdateInstructor)]
        public async Task<IActionResult> UpdateInstractorAsync([FromForm] UpdateInstractorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                              Ok(result) : result.ToProblem();
        }
        [HttpDelete("Delete-Insturctor/{Id}")]
        [HasPermission(Permissions.DeleteInstructor)]
        public async Task<IActionResult> DeleteInstractorAsync([FromRoute] int Id)
        {
            var result = await _mediator.Send(new DeleteInstractorRequest(Id));
            return result.IsSuccess ?
                              Ok(result) : result.ToProblem();
        }
        [HttpPut("Toggle-Status-Instractor/{Id}")]
        public async Task<IActionResult> ToggleStatusInstractorAsync([FromRoute]int Id)
        {
            var result = await _mediator.Send(new ToggleStatusInstractorCommand(Id));
            return result.IsSuccess ?
                              Ok(result) : result.ToProblem();
        }
    }
}
