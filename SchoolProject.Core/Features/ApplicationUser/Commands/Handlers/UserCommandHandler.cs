using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Shared.Absractions;
using SchoolProject.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler(UserManager<User> userManager, IMapper mapper) : IRequestHandler<AddUserCommand, Result<string>>,
                                                                                     IRequestHandler<EditUserCommand,Result<string>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //check email is exist
            var Emailuser = await _userManager.FindByEmailAsync(request.Email);
            if (Emailuser != null)
                return Result.Failure<string>(UserErrors.EmailAlreadyExists);
            //check username is exist
            var UserNameuser= await _userManager.FindByNameAsync(request.UserName);
            if(UserNameuser != null)
                return Result.Failure<string>(UserErrors.UserNameAlreadyExists);
            //mapping
            var UserIdentity = _mapper.Map<User>(request);
            //create
            var result = await _userManager.CreateAsync(UserIdentity, request.Password);
            //faild
            if(!result.Succeeded)
                return Result.Failure<string>(new Error( result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description,StatusCodes.Status409Conflict));
            //secsess
            return Result.Success($"User '{UserIdentity.UserName}' created successfully.");
        }

        public async Task<Result<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(request.Id);
            //if not found
            if (oldUser == null)
                return Result.Failure<string>(UserErrors.UserNotFound);
           //mapping
           var newUser= _mapper.Map(request,oldUser);
            //update
            var result = await _userManager.UpdateAsync(newUser);
            //resutl not success
            if (!result.Succeeded)
                return Result.Failure<string>(new Error(result.Errors.FirstOrDefault()!.Code, result.Errors.FirstOrDefault()!.Description, StatusCodes.Status409Conflict));
            //result success
            return Result.Success($"User '{newUser.UserName}' Edited successfully.");
        }
    }
}
