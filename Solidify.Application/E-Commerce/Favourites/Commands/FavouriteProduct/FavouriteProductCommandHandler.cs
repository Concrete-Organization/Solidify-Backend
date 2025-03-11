using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.E_Commerce.Favourites.Dtos;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Favourites.Commands.FavouriteProduct
{
    public class FavouriteProductCommandHandler(ICurrentUser currentUser,
        IUnitOfWork unitOfWork,
        ICacheService cacheService,
        IMapper mapper) : IRequestHandler<FavouriteProductCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(FavouriteProductCommand request, CancellationToken cancellationToken)
        {
            var product =
                await unitOfWork.GetRepository<Product>().GetAsync(new ProductsSpecification(request.ProductId))
                ?? throw new NotFoundException(nameof(Product), request.ProductId);

            var userId = currentUser.GetUserId();

            var favouriteProducts = await cacheService.GetAsync<FavouriteProductsDto>($"favouriteProducts_{userId}",
                () => Task.FromResult(new FavouriteProductsDto()), TimeSpan.FromDays(15));

            if (favouriteProducts.FavouriteProducts.Any(p => p.Id == product.Id))
                throw new FavoriteAlreadyExistsException(nameof(product));
            
            favouriteProducts.FavouriteProducts.Add(mapper.Map<ProductDto>(product));
            await cacheService.SetAsync($"favouriteProducts_{userId}", favouriteProducts, TimeSpan.FromDays(15));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status204NoContent, null,
                "Product favourites successfully");
        }
    }
}
