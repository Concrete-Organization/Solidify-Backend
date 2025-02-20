using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities;

namespace Solidify.Application.Accounts.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<RevokeTokenCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(rt => rt.Token == request.RefreshToken));
            if (user is null)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null, "Invalid Refresh Token");

            var refreshToken = user.RefreshTokens.Single(t => t.Token == request.RefreshToken);
            if (!refreshToken.IsActive)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status400BadRequest, null, "Invalid Refresh Token");

            refreshToken.RevokedOn = DateTime.UtcNow;

            await userManager.UpdateAsync(user);
            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null, "");
        }
    }
}
