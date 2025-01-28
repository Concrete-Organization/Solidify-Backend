using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Enums;
using Solidify.Domain.Interfaces;

namespace Solidify.Application.E_Commerce.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<GeneralResponseDto>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public MeasurementUnit Measurement { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string CompanyId { get; set; }
    }
}
