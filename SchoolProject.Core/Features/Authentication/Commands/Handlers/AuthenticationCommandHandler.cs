using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Commands.Results;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;

using System.Security.Cryptography;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler(UserManager<User> userManager,IJwtProvider jwtProvider) : IRequestHandler<SigninCommand, Result<SigninResponse>>,
                                                                                                        IRequestHandler<GetRefreshTokenCommand,Result<SigninResponse>>,
                                                                                                        IRequestHandler<RevokeRefreshTokenCommand,Result<bool>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly int _refreshTokenExpriyDays = 14;

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
            var response = await GetSigninResponse(user, _refreshTokenExpriyDays, token, expiresIn);
            // return success result
            return Result.Success(response);

        }
        public async Task<Result<SigninResponse>> Handle(GetRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            //validateToken
            var UserId= _jwtProvider.ValidateToken(request.token);
            if(UserId == null)
                return Result.Failure<SigninResponse>(AuthenticationErrors.TokenNotValid);
            //getUser
            var user = await _userManager.Users
                                          .Include(u => u.refreshTokens)
                                          .FirstOrDefaultAsync(u => u.Id == UserId);
            if (user==null)
                return Result.Failure<SigninResponse>(UserErrors.UserNotFound);
            //selectRefreshToken
            var userRereshToken = user.refreshTokens.SingleOrDefault(x => x.Token == request.refreshToken && x.IsActive);
            if(userRereshToken==null)
                return Result.Failure<SigninResponse>(AuthenticationErrors.RefreshTokenNotFound);
            userRereshToken.RevokedOn = DateTime.UtcNow;
            var (Newtoken, expiresIn) = _jwtProvider.GenerateToken(user);
            var response = await GetSigninResponse(user, _refreshTokenExpriyDays, Newtoken, expiresIn);
            return Result.Success(response);
        }
        public async Task<Result<bool>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var UserId = _jwtProvider.ValidateToken(request.token);
            if (UserId == null)
                return Result.Failure<bool>(AuthenticationErrors.TokenNotValid);
            //getUser
            var user = await _userManager.Users
                                          .Include(u => u.refreshTokens)
                                          .FirstOrDefaultAsync(u => u.Id == UserId);
            if (user == null)
                return Result.Failure<bool>(UserErrors.UserNotFound);
            //selectRefreshToken
            var userRereshToken = user.refreshTokens.SingleOrDefault(x => x.Token == request.refreshToken && x.IsActive);
            if (userRereshToken == null)
                return Result.Failure<bool>(AuthenticationErrors.RefreshTokenNotFound);
            userRereshToken.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return Result.Success(true);

        }
        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        public async Task<SigninResponse> GetSigninResponse(User user,int Days,string token,int expiresIn)
        {
            var resfreshToken = GenerateRefreshToken();
            // mapping to response
            var response = new SigninResponse
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                ExpiresIn = expiresIn,
                RefreshToken = resfreshToken,
                RefreshTokenExpiration = DateTime.UtcNow.AddDays(Days)
            };
            user.refreshTokens.Add(new RefreshToken
            {
                Token = resfreshToken,
                ExpiresOn = response.RefreshTokenExpiration
            });
            await _userManager.UpdateAsync(user);
            return response;
        }

        
    }
}
