using Solidify.Application.Jwt.Dtos;
using Solidify.Domain.Entities;

namespace Solidify.Application.Jwt.Services
{
    public interface IJwtService
    {
        public Task<AuthResponseDto> GenerateToken(ApplicationUser user);
        //   bool ValidateToken(string token);
    }
}
