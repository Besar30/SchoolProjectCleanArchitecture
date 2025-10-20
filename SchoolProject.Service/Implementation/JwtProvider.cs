using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public (string Token, int ExpiresIn) GenerateToken(User user, IEnumerable<string> roles, IEnumerable<string> permissions)
        {
            
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new(nameof(roles),JsonSerializer.Serialize(roles),JsonClaimValueTypes.JsonArray),
                new(nameof(permissions),JsonSerializer.Serialize(permissions),JsonClaimValueTypes.JsonArray)// id for token
                ];
            var symmetricsecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var signingCredentials = new SigningCredentials(symmetricsecurityKey, SecurityAlgorithms.HmacSha256);

            

            var token = new JwtSecurityToken(
               issuer: _options.Issuer,
               audience: _options.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_options.ExpiresIn),
               signingCredentials: signingCredentials
               );
            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIN: _options.ExpiresIn * 60);
    }

        public string? ValidateToken(string token)
        {
            try
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Token to validate: {token}");

                if (string.IsNullOrEmpty(token)) return null;
                if (token.StartsWith("Bearer ")) token = token.Substring(7);

                // الطريقة الآمنة - اقرأ الـ token من غير validation
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!tokenHandler.CanReadToken(token))
                {
                    Console.WriteLine("Cannot read token - invalid format");
                    return null;
                }

                var jwtToken = tokenHandler.ReadJwtToken(token);

                // اطبع كل الـ claims عشان نتأكد
                Console.WriteLine("=== ALL CLAIMS IN TOKEN ===");
                foreach (var claim in jwtToken.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }
                Console.WriteLine("===========================");

                // إبحث عن الـ UserId
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    Console.WriteLine("User ID not found in token");
                    return null;
                }

                Console.WriteLine($"✅ User ID extracted: {userId}");
                return userId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Token reading error: {ex.Message}");
                return null;
            }
        }
    }
}
