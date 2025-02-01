using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.CartItems.Commands.AddCartItem
{
    public class AddCartItemCommandHandler(ICacheService cacheService,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<AddCartItemCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var cart = await cacheService.GetAsync<Cart>("cart", () => Task.FromResult(new Cart()), TimeSpan.FromDays(15));

            var productRepository = unitOfWork.GetRepository<Product>();

            var product = await productRepository.GetAsync(new ProductsSpecification(request.Id))
                          ?? throw new NotFoundException(nameof(Product), request.Id);

            var existingCartItem = cart.Items.FirstOrDefault(i => i.Id == request.Id);

            if (existingCartItem is null)
            {
                var cartItem = mapper.Map<CartItem>(product);
                cart.Items!.Add(cartItem);
            }
            else
                existingCartItem.IncrementQuantity();

            cart.GetTotalPrice();

            if (product.Stock - existingCartItem.Quantity < 0)
                return GeneralResponse.CreateResponse(false, StatusCodes.Status405MethodNotAllowed, null,
                    $"{product.Name} out of stock");

            await cacheService.SetAsync("cart", cart, TimeSpan.FromDays(15));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, null,
                $"{product.Name} Added to cart Successfully");
        }
    }
}
