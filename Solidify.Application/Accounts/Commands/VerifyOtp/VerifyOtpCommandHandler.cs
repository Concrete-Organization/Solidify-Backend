using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities;

namespace Solidify.Application.Accounts.Commands.VerifyOtp
{
    public class VerifyOtpCommandHandler(IMemoryCache cache
        , UserManager<ApplicationUser> userManager) : IRequestHandler<VerifyOtpCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new GeneralResponseDto
                {
                    IsSucceeded = false,
                    StatusCode = 404,
                    Message = "no user with this email"
                };
            }

            if (!cache.TryGetValue($"{request.Email}_Verified", out string storedOtp) || storedOtp != request.Otp)
            {
                return new GeneralResponseDto
                {
                    IsSucceeded = false,
                    Message = "Invalid or expired OTP",
                    StatusCode = 400
                };
            }

            cache.Set($"{request.Email}_Verified", true, TimeSpan.FromMinutes(10));
            return new GeneralResponseDto
            {
                StatusCode = 200,
                IsSucceeded = true,
                Message = "OTP verified successfully. You can now reset your password."
            };
        }
    }
}
