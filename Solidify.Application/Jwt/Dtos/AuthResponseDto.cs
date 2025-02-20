namespace Solidify.Application.Jwt.Dtos
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
