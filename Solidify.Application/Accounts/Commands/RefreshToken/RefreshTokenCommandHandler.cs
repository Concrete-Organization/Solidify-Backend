using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Jwt.Services;
using Solidify.Domain.Entities;
using Solidify.Domain.Exceptions;

namespace Solidify.Application.Accounts.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler(UserManager<ApplicationUser> userManager,
        IJwtService jwtService) : IRequestHandler<RefreshTokenCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(rt => rt.Token == request.RefreshToken));
            if (user is null)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null, "Invalid Refresh Token");

            var refreshToken = user.RefreshTokens.Single(t => t.Token == request.RefreshToken);
            if(!refreshToken.IsActive)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null, "Invalid Refresh Token");

            refreshToken.RevokedOn = DateTime.UtcNow;

            var authResponse = await jwtService.GenerateToken(user);

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, authResponse, "");
        }
    }
}
