using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Accounts.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<GeneralResponseDto>
    {
        public string RefreshToken { get; set; }
    }
}
