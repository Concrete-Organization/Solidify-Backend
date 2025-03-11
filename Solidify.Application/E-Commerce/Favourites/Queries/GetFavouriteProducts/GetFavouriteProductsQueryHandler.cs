using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.User;
using Solidify.Application.E_Commerce.Favourites.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.Favourites.Queries.GetFavouriteProducts
{
    public class GetFavouriteProductsQueryHandler(ICurrentUser currentUser,
        IMapper mapper,
        ICacheService cacheService) : IRequestHandler<GetFavouriteProductsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetFavouriteProductsQuery request, CancellationToken cancellationToken)
        {
            var userId = currentUser.GetUserId();

            var favouriteProducts = await cacheService.GetAsync<FavouriteProductsDto>($"favouriteProducts_{userId}",
                 () =>  Task.FromResult(new FavouriteProductsDto()), TimeSpan.FromDays(15));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, favouriteProducts, "");
        }
    }
}
