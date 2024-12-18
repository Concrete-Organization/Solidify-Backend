
using Microsoft.Extensions.Caching.Memory;

namespace Solidify.Application.Otp.Services
{
    public class OtpService(IMemoryCache memoryCache) : IOtpService
    {
        public async Task<string> GenerateOtpAsync(string email)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            memoryCache.Set($"{email}_Verified", otp, TimeSpan.FromMinutes(10));
            return otp;
        }

        public async Task RemoveOtpAsync(string email)
        {
            memoryCache.Remove($"{email}_Verified");
        }
    }
}
