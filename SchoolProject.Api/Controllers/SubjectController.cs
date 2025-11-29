using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.pagination;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class SubjectController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("Get-Subject-By-Id/{Id}")]
        public async Task<IActionResult> GetSubjectByIdAsync([FromRoute] int Id)
        {
            var result = await _mediator.Send(new GetSubjectByIdRequestQuery(Id));
            return result.IsSuccess ?
               Ok(result) : result.ToProblem();
        }
        [HttpGet("Get-All-Subject-Pagination-Filter")]
        [HasPermission(Permissions.GetSubjects)]
        public async Task<IActionResult> GetAllSubjectAsync([FromQuery]RequestFilters requestFilters)
        {
            var result = await _mediator.Send(new GetAllSubjectRequestQuery(requestFilters));
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpPost("Add-Subject")]
        [HasPermission(Permissions.AddSubject)]
        public async Task<IActionResult> AddSubjectAsync(AddSubjectRequestCommand command)
        {
            var result= await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }
        [HttpPut("Update-Subject")]
        [HasPermission(Permissions.UpdateSubject)]
        public async Task<IActionResult> UpdateSubjectAsync([FromBody] UpdateSubjectRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }
        [HttpDelete("Delete-Subject/{Id}")]
        [HasPermission(Permissions.UpdateSubject)]
        public async Task<IActionResult> DeleteSubjectAsync([FromRoute]int Id)
        {
            var result = await _mediator.Send(new DeleteSubjectRequestCommand(Id));
            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }
    }
}
