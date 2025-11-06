using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.AuthServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.AuthServices.Implementations
{
    public class CurrentUserServices(IHttpContextAccessor httpContextAccessor,UserManager<User> userManager) : ICurrentUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<User> user()
        {
            var userId = GetUserId();
            var user= await _userManager.FindByIdAsync(userId);
            return user;
        }

        public string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                throw new UnauthorizedAccessException();
            return userId;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var User =await user();
            var roles = await _userManager.GetRolesAsync(User);
            return roles.ToList();
        }
    }
}
