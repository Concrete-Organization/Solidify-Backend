using Solidify.Application.E_Commerce.Products.Dtos;

namespace Solidify.Application.E_Commerce.Favourites.Dtos
{
    public class FavouriteProductsDto
    {
        public virtual ICollection<ProductDto>? FavouriteProducts { get; set; } = new HashSet<ProductDto>();
    }
}
