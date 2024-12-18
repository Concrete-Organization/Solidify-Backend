using MediatR;
using Microsoft.AspNetCore.Identity;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Email.Services;
using Solidify.Application.Otp.Services;
using Solidify.Domain.Entities;

namespace Solidify.Application.Accounts.Commands.SendOtp
{
    public class SendOtpCommandHandler(IEmailService emailService
        , IOtpService otpService
        , UserManager<ApplicationUser> userManager) : IRequestHandler<SendOtpCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(SendOtpCommand request, CancellationToken cancellationToken)
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

            var otp = await otpService.GenerateOtpAsync(request.Email);
            var emailResponse = await emailService
                .SendEmailAsync(request.Email, "Your Password Reset OTP Code"
                , $"Your OTP code for resetting your password is: {otp}");


            return new GeneralResponseDto
            {
                IsSucceeded = emailResponse.IsSucceeded,
                StatusCode = emailResponse.StatusCode,
                Message = emailResponse.Message
            };

        }
     
    }

}
