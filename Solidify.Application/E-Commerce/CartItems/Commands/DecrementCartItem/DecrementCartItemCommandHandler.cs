using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.CartItems.Commands.DecrementCartItem;

public class DecrementCartItemCommandHandler(ICacheService cacheService) : IRequestHandler<DecrementCartItemCommand, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(DecrementCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await cacheService.GetAsync<Cart>("cart");

        var existingCartItem = cart.Items.FirstOrDefault(i => i.Id == request.Id)
                               ?? throw new NotFoundException(nameof(CartItem), request.Id);

        existingCartItem.DecrementQuantity();
        if (existingCartItem.Quantity < 1)
            cart.Items.Remove(existingCartItem);

        cart.GetTotalPrice();

        await cacheService.SetAsync("cart", cart, TimeSpan.FromDays(15));

        return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
            $"{existingCartItem.Name} decremented Successfully");
    }
}