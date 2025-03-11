using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.CartItems.Commands.DeleteCartItem
{
    public class DeleteCartItemCommand(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
