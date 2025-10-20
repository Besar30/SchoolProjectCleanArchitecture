using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
namespace SchoolProject.Service.Implementation
{
    public class AuthrizationServices(RoleManager<ApplicationRole> roleManager) : IAuthrizationServices
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

        public async Task<bool> AddRoleAsync(string roleName)
        {
            var IdentityRole= new ApplicationRole();
            IdentityRole.Name = roleName;
            var result =await _roleManager.CreateAsync(IdentityRole);
            if(!result.Succeeded) 
                return false;
            return true;
        }

        public async Task<bool> IsRoleIsExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
    }
}
