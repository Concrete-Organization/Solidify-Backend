using Microsoft.Extensions.Options;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Email.Setting;
using System.Net;
using System.Net.Mail;

namespace Solidify.Application.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task<GeneralResponseDto> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            GeneralResponseDto generalResponse = new GeneralResponseDto();

            try
            {

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.UserName, "Solidify Application"),
                    To = { new MailAddress(recipientEmail) },
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                using (var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                    smtpClient.EnableSsl = true;
                    await smtpClient.SendMailAsync(message);
                }

                generalResponse.IsSucceeded = true;
                generalResponse.Message = "Email sent successfully.";
                generalResponse.StatusCode = 200;
            }
            catch (Exception ex)
            {
                generalResponse.IsSucceeded = false;
                generalResponse.Message = $"Failed to send email: {ex.Message}";
                generalResponse.StatusCode = 400;
            }
            return generalResponse;
        }
    }
}
