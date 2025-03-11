using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.CartItems.Commands.DeleteCartItem
{
    public class DeleteCartItemCommandHandler(ICacheService cacheService,
        ICurrentUser currentUser) : IRequestHandler<DeleteCartItemCommand, GeneralResponseDto>

    {
        public async Task<GeneralResponseDto> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var userId = currentUser.GetUserId();

            var cart = await cacheService.GetAsync<Cart>($"cart_{userId}");

            var existingCartItem = cart.Items.FirstOrDefault(i => i.Id == request.Id)
                                   ?? throw new NotFoundException(nameof(CartItem), request.Id);

            cart.Items.Remove(existingCartItem);

            cart.GetTotalPrice();

            await cacheService.SetAsync($"cart_{userId}", cart, TimeSpan.FromDays(15));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
                $"{existingCartItem.Name} deleted Successfully");
        }
    }
}
