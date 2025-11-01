using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Commands.Results;
using SchoolProject.Core.Features.Authentication.Queires.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastructure.Abstracts.Const;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementation;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler(UserManager<User> userManager,IJwtProvider jwtProvider
        ,ApplicationDBContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor,IEmailService emailService,IUrlHelper urlHelper,IUserService userService) : IRequestHandler<SigninCommand, Result<SigninResponse>>,
                                                                                                        IRequestHandler<GetRefreshTokenCommand,Result<SigninResponse>>,
                                                                                                        IRequestHandler<RevokeRefreshTokenCommand,Result<bool>>
                                                                                                        ,IRequestHandler<RegistrationCommand,Result<string>>,
                                                                                                          IRequestHandler<ConfirmEmailCommand,Result<string>>,
                                                                                                           IRequestHandler<ResetPasswordCommand,Result<string>>,
                                                                                                           IRequestHandler<ConfirmCodeRestPasswordCommand,Result<string>>
                                                                                                           ,IRequestHandler<ResetNewPasswordCommand,Result<string>>
                                                                                                          
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly ApplicationDBContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IEmailService _emailService = emailService;
        private readonly IUrlHelper _urlHelper = urlHelper;
        private readonly IUserService _userService = userService;
        private readonly int _refreshTokenExpriyDays = 14;

        public async Task<Result<string>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var EmailIsExits= await _userManager.FindByEmailAsync(request.Email);
            if (EmailIsExits != null)
                return Result.Failure<string>(AuthenticationErrors.EmailAlreadyExists);
            var UserNameIsExist= await _userManager.FindByNameAsync(request.UserName);
            if(UserNameIsExist != null)
                return Result.Failure<string>(AuthenticationErrors.UserNameAlreadyExists);
            var UserIdentity = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(UserIdentity, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(UserIdentity, DefaultRoles.Member);
                //send confirm email
                var code= await _userManager.GenerateEmailConfirmationTokenAsync(UserIdentity);
            //    var encodedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                //create Link
                var RequestAccessor = _httpContextAccessor.HttpContext.Request;
                var ReturnUrl = RequestAccessor.Scheme + "://" + RequestAccessor.Host + 
                    _urlHelper.Action("ConfirmEmail", "Authentication", new { UserId = UserIdentity.Id, code = code });
                   // $"/api/Authentication/ConfirmEmail?UserId={UserIdentity.Id}&code={code}";
                //body
                var resultOfConfirmEmail = await _emailService.SendMassege(UserIdentity.Email!, ReturnUrl, "Confirm Your Email");
                if(!resultOfConfirmEmail.IsSuccess)
                    return Result.Failure<string>(AuthenticationErrors.ConfirmEmail);
                return Result.Success("User created successfully");
            }
            return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
        }
        public async Task<Result<SigninResponse>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            //check if email exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) 
                return Result.Failure<SigninResponse>(UserErrors.InvalidCredentials);
            //check is user not Disable
            if(user.IsDisabled)
                return Result.Failure< SigninResponse>(UserErrors.UserIsDisabled);
            //check password
            var IsValidPassword = await _userManager.CheckPasswordAsync(user,request.Password);
            if (!IsValidPassword)
                return Result.Failure<SigninResponse>(UserErrors.InvalidCredentials);
            //check email confirmed
            if (!user.EmailConfirmed)
                return Result.Failure<SigninResponse>(AuthenticationErrors.EmailUserNotConfirmed);
            // generate token
            var (userRoles, userPermissions) = await GetRolesAndPermissions(user, cancellationToken);
            var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
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

            if (user.IsDisabled)
                return Result.Failure<SigninResponse>(UserErrors.UserIsDisabled);
            //selectRefreshToken
            var userRereshToken = user.refreshTokens.SingleOrDefault(x => x.Token == request.refreshToken && x.IsActive);
            if(userRereshToken==null)
                return Result.Failure<SigninResponse>(AuthenticationErrors.RefreshTokenNotFound);
            userRereshToken.RevokedOn = DateTime.UtcNow;
            var (userRoles, userPermissions) = await GetRolesAndPermissions(user, cancellationToken);
            var (Newtoken, expiresIn) = _jwtProvider.GenerateToken(user,userRoles,userPermissions);
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
        public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return Result.Failure<string>(UserErrors.UserNotFound);

          //  var decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.code));

            var confirmEmail = await _userManager.ConfirmEmailAsync(user, request.code);
            if (!confirmEmail.Succeeded)
                return Result.Failure<string>(AuthenticationErrors.InvalidEmailConfirmationToken);
            return Result.Success("Email confirmed successfully");
        }
        public async Task<Result<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.ResetPasswordService(request.Email);
            return result.IsSuccess ?
                Result.Success("Reset Code has been sent successfully.") : Result.Failure<string>(result.error);
        }
        public async Task<Result<string>> Handle(ConfirmCodeRestPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.ResetPasswordConfirmationService(request.Email, request.Code);
            return result.IsSuccess ?
                Result.Success("Code confirmed successfully. You can now reset your password.") : Result.Failure<string>(result.error);
        }
        public async Task<Result<string>> Handle(ResetNewPasswordCommand request, CancellationToken cancellationToken)
        {
           var result= await _userService.ResetPasswordConfirmationConfirmationService(request.Email,request.NewPassword,request.ConfirmPassword);
            return result.IsSuccess ?
                           Result.Success("Password reset successfully.") : Result.Failure<string>(result.error);
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
                UserName=user.UserName!,
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

        private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetRolesAndPermissions(User user, CancellationToken cancellationToken)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userPermissions = await (from r in _context.Roles
                                         join p in _context.RoleClaims
                                         on r.Id equals p.RoleId
                                         where userRoles.Contains(r.Name!)
                                         select p.ClaimValue!)
                                     .Distinct()
                                     .ToListAsync(cancellationToken);
            return (userRoles, userPermissions);
        }


    }
}
