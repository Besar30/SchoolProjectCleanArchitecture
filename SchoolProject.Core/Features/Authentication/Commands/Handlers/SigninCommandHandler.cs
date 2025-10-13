using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Commands.Results;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class SigninCommandHandler(UserManager<User> userManager,IJwtProvider jwtProvider) : IRequestHandler<SigninCommand, Result<SigninResponse>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<SigninResponse>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            //check if email exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) 
                return Result.Failure<SigninResponse>(UserErrors.InvalidCredentials);
            //check password
            var IsValidPassword = await _userManager.CheckPasswordAsync(user,request.Password);
            if (!IsValidPassword)
                return Result.Failure<SigninResponse>(UserErrors.InvalidCredentials);
            // generate token
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);
            // mapping to response
            var response = new SigninResponse
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                ExpiresIn = expiresIn
            };

            // return success result
            return Result.Success(response);

        }
    }
}
