using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Favourites.Commands.FavouriteProduct;

public class FavouriteProductCommand : IRequest<GeneralResponseDto>
{
    public string ProductId { get; set; }
}