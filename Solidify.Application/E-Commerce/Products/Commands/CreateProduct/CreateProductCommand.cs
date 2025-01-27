using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Interfaces;

namespace Solidify.Application.E_Commerce.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<GeneralResponseDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Measurement { get; set; }
        public string Image { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string CompanyId { get; set; }
    }
}
