using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queires.Models;
using SchoolProject.Core.Filters;
using SchoolProject.Core.pagination;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =DefaultRoles.Admin)]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("")]
        [HasPermission(Permissions.GetStudents)]

        public async Task<IActionResult> GetStudent([FromQuery] RequestFilters filters)
        {
            var result = await _mediator.Send(new GetStudentListQuery
            {
                RequestFilters = filters
            });

            return result.IsSuccess
                ? Ok(result.Value)
                : result.ToProblem();
        }
        [HttpGet("{Id}")]
        [HasPermission(Permissions.GetStudents)]

        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var result= await _mediator.Send(new GetStudentByIdQuery(Id));
            return result.IsSuccess ?
                Ok(result.Value) :
                result.ToProblem();
        }
        [HttpPost("")]
        [HasPermission(Permissions.AddStudent)]

        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result.Value) : result.ToProblem();
        }

        [HttpPut("")]
        [HasPermission(Permissions.UpdateStudent)]

        public async Task<IActionResult> EditStudentAsync([FromBody] EditStudentRequest request)
        {
                var result = await _mediator.Send(request);
                return result.IsSuccess ?
                    Ok(result.Value) : result.ToProblem();
        }
        [HttpDelete("{Id}")]
        // [ServiceFilter(typeof(AuthFilter))]
        [HasPermission(Permissions.DeleteStudent)]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int Id)
        {
            var result =await _mediator.Send(new DeleteStudentRequest(Id));
            return result.IsSuccess ?
                Ok(result):
                result.ToProblem();
        }

        [HttpPut("Toggle-Status-Student/{Id}")]
        public async Task<IActionResult> ToggleStatusStudentAsync([FromRoute] int Id)
        {
            var result = await _mediator.Send(new ToggleStatusStudentCommand(Id));
            return result.IsSuccess ?
                              Ok(result) : result.ToProblem();
        }
    }
}
