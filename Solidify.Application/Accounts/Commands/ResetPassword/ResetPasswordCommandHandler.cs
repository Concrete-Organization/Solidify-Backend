using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Otp.Services;
using Solidify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler(IMemoryCache cache
        , UserManager<ApplicationUser> userManager
        , IOtpService otpService) : IRequestHandler<ResetPasswordCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
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

            if (!cache.TryGetValue($"{request.Email}_Verified", out bool otpVerified) || !otpVerified)
            {
                return new GeneralResponseDto
                {
                    IsSucceeded = false,
                    Message = "Invalid or expired OTP",
                    StatusCode = 400
                };
            }

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, resetToken, request.Password);
            if (!result.Succeeded)
            {
                return new GeneralResponseDto
                {
                    IsSucceeded = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description)),
                    StatusCode = 400
                };
            }

            await otpService.RemoveOtpAsync(request.Email);
            return new GeneralResponseDto
            {
                IsSucceeded = true,
                StatusCode = 200,
                Message = "Password reset successfully"
            };
        }
        
    }
}
