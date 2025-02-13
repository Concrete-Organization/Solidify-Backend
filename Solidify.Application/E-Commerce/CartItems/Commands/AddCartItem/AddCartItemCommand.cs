using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem
{
    public class AddCartItemCommand(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
