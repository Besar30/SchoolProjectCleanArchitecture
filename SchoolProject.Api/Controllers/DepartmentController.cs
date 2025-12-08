using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Features.Departments.Queires.Models;
using SchoolProject.Infrastructure.Abstracts.Const;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class DepartmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("Get-All-Department")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result= await _mediator.Send(new GetAllDepartmentQuery());
            return result.IsSuccess ?
              Ok(result) : result.ToProblem();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(Id));
            return response.IsSuccess ?
                Ok(response) : response.ToProblem();
        }
        [HttpPost("Add-Department")]
        public async Task<IActionResult> AddDepartmentAsync([FromBody]AddDepartmentRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpPut("Update-Department")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromBody] UpdateDepartmentRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpDelete("Delete-Department/{Id}")]
        public async Task<IActionResult> DeleteDepartmentAsync([FromRoute]int Id)
        {
            var result = await _mediator.Send(new DeleteDepartmentRequestCommand(Id));
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }

        [HttpGet("Get-Department-Student-Count-By-View")]
        public async Task<IActionResult> GetDepartmentStudentCount()
        {
            var result = await _mediator.Send(new GetDepartmentStudentCountQuery());
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpGet("Get-Department-Student-Count-By-Id-By-Procedures/{Id}")]
        public async Task<IActionResult>GetDepartmentStudentCountByIdProc([FromRoute]int Id)
        {
            var result= await _mediator.Send(new GetDepartmentStudentCountByIdProcQuery(Id));
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }

    }

}
