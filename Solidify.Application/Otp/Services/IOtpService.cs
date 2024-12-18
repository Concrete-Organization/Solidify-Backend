namespace Solidify.Application.Otp.Services
{
    public interface IOtpService
    {
        Task<string> GenerateOtpAsync(string email);
        Task RemoveOtpAsync(string email);
    }
}
