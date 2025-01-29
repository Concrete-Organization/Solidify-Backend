using Microsoft.AspNetCore.Http;

namespace Solidify.Application.E_Commerce.Products.Dtos
{
    public class UpdateProductDto
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile? Image { get; set; }
    }
}
