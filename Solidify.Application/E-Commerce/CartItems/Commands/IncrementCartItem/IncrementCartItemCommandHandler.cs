using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.CartItems.Commands.IncrementCartItem;

public class IncrementCartItemCommandHandler(ICacheService cacheService,
    IUnitOfWork unitOfWork) : IRequestHandler<IncrementCartItemCommand, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(IncrementCartItemCommand request, CancellationToken cancellationToken)
    {
        var productRepository = unitOfWork.GetRepository<Product>();

        var product = await productRepository.GetAsync(new ProductsSpecification(request.Id))
                      ?? throw new NotFoundException(nameof(Product), request.Id);

        var cart = await cacheService.GetAsync<Cart>("cart");

        var existingCartItem = cart.Items.FirstOrDefault(i => i.Id == request.Id)
                               ?? throw new NotFoundException(nameof(CartItem), request.Id);

        existingCartItem.IncrementQuantity();

        cart.GetTotalPrice();

        if (product.Stock - existingCartItem.Quantity < 0)
            return GeneralResponse.CreateResponse(false, StatusCodes.Status405MethodNotAllowed, null,
                $"{product.Name} there is no more than {existingCartItem.Quantity} in stock");

        await cacheService.SetAsync("cart", cart, TimeSpan.FromDays(15));

        return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
            $"{existingCartItem.Name} incremented Successfully");
    }
}