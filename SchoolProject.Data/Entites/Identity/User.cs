using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entites.Identity
{
    public class User:IdentityUser
    {
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
