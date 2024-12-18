using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Email.Services
{
    public interface IEmailService
    {
        Task<GeneralResponseDto> SendEmailAsync(string recipientEmail, string subject, string body);
    }
}
