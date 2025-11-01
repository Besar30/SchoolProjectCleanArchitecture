using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites.Identity
{
    public class User:IdentityUser
    {
        public string? Address { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
        public bool IsDisabled { get; set; }
        [EncryptColumn]
        public string? Code { get; set; }
        public DateTime? CodeExpireAt { get; set; }
        public bool CodeIsUsed { get; set; } = false;
        public virtual List<RefreshToken> refreshTokens { get; set; } = [];
    }
}
