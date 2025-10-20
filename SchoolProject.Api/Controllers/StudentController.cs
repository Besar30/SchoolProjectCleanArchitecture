using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queires.Models;
using SchoolProject.Core.pagination;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles =DefaultRoles.Admin)]
    [HasPermission(Permissions.GetStudents)]

    public class StudentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("")]
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
        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var result= await _mediator.Send(new GetStudentByIdQuery(Id));
            return result.IsSuccess ?
                Ok(result.Value) :
                result.ToProblem();
        }
        [HttpPost("")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result.Value) : result.ToProblem();
        }

        [HttpPut("")]
        public async Task<IActionResult> EditStudentAsync([FromBody] EditStudentRequest request)
        {
                var result = await _mediator.Send(request);
                return result.IsSuccess ?
                    Ok(result.Value) : result.ToProblem();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int Id)
        {
            var result =await _mediator.Send(new DeleteStudentRequest(Id));
            return result.IsSuccess ?
                Ok(result):
                result.ToProblem();
        }
    

    }
}
