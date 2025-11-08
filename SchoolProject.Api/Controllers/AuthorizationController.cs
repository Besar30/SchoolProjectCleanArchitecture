using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Const;
using SchoolProject.Core.Features.Authrization.Commands.Models;
using SchoolProject.Core.Features.Authrization.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Service.Abstracts.Filter;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = DefaultRoles.Admin)]
    public class AuthorizationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        [HasPermission(Permissions.AddRoles)]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleCommand request)
        {
            var result = await _mediator.Send(request);
            return result.IsSuccess ?
                Ok(result) : result.ToProblem();
        }
        [HttpGet("GetRoles")]
        [HasPermission(Permissions.GetRoles)]
        public async Task<IActionResult> GetAllRolesAsync([FromQuery] bool? IncludeDeleted=false)
        {
            var result = await _mediator.Send(new GetAllRoleQuery(IncludeDeleted));
            return result.IsSuccess ?
                 Ok(result) : result.ToProblem();
        }
        [HttpGet("GetRoleByIdAndHisPermissions")]
        [HasPermission(Permissions.GetRoles)]

        public async Task<IActionResult> GetAllRolesAsync([FromQuery] string Id)
        {
            var result = await _mediator.Send(new GetRoleDetailsByIdQuery(Id));
            return result.IsSuccess ?
                 Ok(result) : result.ToProblem();
        }
        [HttpPut("EditRole")]
        [HasPermission(Permissions.UpdateRoles)]

        public async Task<IActionResult> EditRoleAsync([FromBody] UpdateRoleCommand request)
        {
            var result = await _mediator.Send(new UpdateRoleCommand
            {
                Id = request.Id,
                RoleName = request.RoleName,
                Permission = request.Permission
            });
            return result.IsSuccess?
                Ok(result) : result.ToProblem();
        }
        [HttpPut("ToggleStatues/{Id}")]
        public async Task<IActionResult> ToggleStatuesAsync([FromRoute]string Id)
        {
            var result= await _mediator.Send(new ToggleStatusCommand(Id));
            return result.IsSuccess ?
              Ok(result) : result.ToProblem();
        }
    }
}
