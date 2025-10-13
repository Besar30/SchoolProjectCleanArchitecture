using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class JwtOptions
    {
        public static string NameSection = "Jwt";
        [Required]
        public string Key { get; init; }= string.Empty;
        [Required]
        public string Issuer { get; init; } = string.Empty;
        [Required]
        public string Audience { get; init; } = string.Empty;
        [Range(1,int.MaxValue)]
        public int ExpiresIn { get; init; }
    }
}