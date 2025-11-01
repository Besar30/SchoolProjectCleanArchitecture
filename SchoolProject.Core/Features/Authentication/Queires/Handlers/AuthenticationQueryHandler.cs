using MediatR;
using SchoolProject.Core.Features.Authentication.Queires.Models;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queires.Handlers
{
    public class AuthenticationQueryHandler(IUserService userService) : IRequestHandler<ResetConfirmEmailQuery, Result<string>>
    {
        private readonly IUserService _userService = userService;

        public async Task<Result<string>> Handle(ResetConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.ResetConfirmEmailService(request.Email);
            if (!result.IsSuccess)
                return Result.Failure<string>(result.error);
            return Result.Success("A new confirmation email has been sent.");
        }
    }
}
