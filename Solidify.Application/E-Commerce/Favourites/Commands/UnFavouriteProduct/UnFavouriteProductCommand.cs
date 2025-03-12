using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Favourites.Commands.UnFavouriteProduct
{
    public class UnFavouriteProductCommand : IRequest<GeneralResponseDto>
    {
        public string ProductId { get; set; }
    }
}
