using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Student_Subject.Commands.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Add-Student-Subject")]
        public async Task<IActionResult> AddStudentSubjectAsync([FromBody] AddStudentSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpPost("Update-Student-Sublect")]
        public async Task<IActionResult> UpdateStudentSubjectAsync([FromBody] UpdateStudentSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
    }
}
