namespace Solidify.Application.Accounts.Commands.Login.Dto
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
