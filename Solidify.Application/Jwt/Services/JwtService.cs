using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Solidify.Application.Jwt.Dtos;
using Solidify.Domain.Entities;

namespace Solidify.Application.Jwt.Services
{
    public class JwtService(IOptionsMonitor<JwtSettings> jwtSettings,
        UserManager<ApplicationUser> userManager) : IJwtService
    {
         
        public async Task<AuthResponseDto> GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("User Name", user.UserName),
                new Claim("Email", user.Email),
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.CurrentValue.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireHours = jwtSettings.CurrentValue.ExpireHours;


            var token = new JwtSecurityToken(
                issuer: jwtSettings.CurrentValue.Issuer,
                audience: jwtSettings.CurrentValue.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(expireHours),
                signingCredentials: creds);

            var authResponseDto = new AuthResponseDto();

            authResponseDto.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            authResponseDto.ExpiresOn = token.ValidTo;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var refreshToken = user.RefreshTokens.Single(t => t.IsActive);
                authResponseDto.RefreshToken = refreshToken.Token;
                authResponseDto.RefreshTokenExpiration = refreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authResponseDto.RefreshToken = refreshToken.Token;
                authResponseDto.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await userManager.UpdateAsync(user);
            }
            return authResponseDto;
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(15)
            };
        }
    }
}
