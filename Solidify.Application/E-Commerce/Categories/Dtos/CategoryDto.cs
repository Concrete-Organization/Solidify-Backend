using Solidify.Application.E_Commerce.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
