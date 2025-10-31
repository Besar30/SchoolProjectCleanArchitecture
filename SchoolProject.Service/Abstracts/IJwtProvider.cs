using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IJwtProvider
    {
        (string Token, int ExpiresIn) GenerateToken(User user,IEnumerable<string> roles, IEnumerable<string> permissions);
        string? ValidateToken(string token);

    }
}
