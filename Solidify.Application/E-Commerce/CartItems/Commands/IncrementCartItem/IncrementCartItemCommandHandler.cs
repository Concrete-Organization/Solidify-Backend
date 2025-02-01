using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.CartItems.Commands.IncrementCartItem;

public class IncrementCartItemCommandHandler(ICacheService cacheService) : IRequestHandler<IncrementCartItemCommand, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(IncrementCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await cacheService.GetAsync<Cart>("cart");

        var existingCartItem = cart.Items.FirstOrDefault(i => i.Id == request.Id)
                               ?? throw new NotFoundException(nameof(CartItem), request.Id);

        existingCartItem.IncrementQuantity();

        cart.GetTotalPrice();

        await cacheService.SetAsync("cart", cart, TimeSpan.FromDays(15));

        return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
            $"{existingCartItem.Name} incremented Successfully");
    }
}