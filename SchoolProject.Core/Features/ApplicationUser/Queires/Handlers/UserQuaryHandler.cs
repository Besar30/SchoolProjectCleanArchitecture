using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.ApplicationUser.Queires.Models;
using SchoolProject.Core.Features.ApplicationUser.Queires.Results;
using SchoolProject.Core.pagination;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Shared.Absractions;

using SchoolProject.Shared.Errors;
namespace SchoolProject.Core.Features.ApplicationUser.Queires.Handlers
{
    public class UserQuaryHandler(UserManager<User> userManager,IMapper mapper) : IRequestHandler<GetUserPaginationQuery, Result<PaginatedList<GetUserPaginationResponse>>>,
        IRequestHandler<GetUserByIdQuery,Result<GetUserByIdResponse>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginatedList<GetUserPaginationResponse>>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
           var Users =  _userManager.Users.AsQueryable();
            var mappedQuery = _mapper.ProjectTo<GetUserPaginationResponse>(Users);

           var PaginationList = await PaginatedList<GetUserPaginationResponse>.CreateAsync(
               mappedQuery, request.RequestFilters.PageNumber, request.RequestFilters.PageSize, cancellationToken);
            return Result.Success(PaginationList);
        }

        public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
                return Result.Failure<GetUserByIdResponse>(UserErrors.UserNotFound);
            var userRoles =await _userManager.GetRolesAsync(user);
            var usermapped= _mapper.Map<GetUserByIdResponse>(user);
            usermapped.Roles = userRoles;
            return Result.Success(usermapped);
        }
    }
}
