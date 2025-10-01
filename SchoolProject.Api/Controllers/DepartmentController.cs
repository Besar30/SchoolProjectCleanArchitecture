using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Departments.Queires.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(Id));
            return response.IsSuccess ?
                Ok(response) : response.ToProblem();
        }
    }

}
