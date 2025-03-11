using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.CartItems.Commands.IncrementCartItem
{
    public class IncrementCartItemCommand(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
