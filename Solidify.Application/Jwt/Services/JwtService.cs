using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Solidify.Application.Jwt.Dtos;
using Solidify.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solidify.Application.Jwt.Services
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
         
        public AuthResponseDto GenerateToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("User Name", user.UserName),
                new Claim("Email", user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("Roles", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresDays = int.Parse(configuration["Jwt:ExpireDays"]);


            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(expiresDays),
                signingCredentials: creds);

            AuthResponseDto authResponseDto = new AuthResponseDto();

            authResponseDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authResponseDto.ExpireDate = token.ValidTo;
            return authResponseDto;
        }
    }
}
