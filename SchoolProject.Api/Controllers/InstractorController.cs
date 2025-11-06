using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Api.Const;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstractorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Add-Insturctor")]
        public async Task<IActionResult> AddInstractorAsync([FromForm] AddInstractorCommand command)
        {
            var result= await _mediator.Send(command);
            return result.IsSuccess?
                              Ok(result) : result.ToProblem();
        }
    }
}
