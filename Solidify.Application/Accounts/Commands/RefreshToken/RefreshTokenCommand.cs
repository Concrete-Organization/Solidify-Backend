using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Accounts.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<GeneralResponseDto>
    {
        public string RefreshToken { get; set; }
    }
}
