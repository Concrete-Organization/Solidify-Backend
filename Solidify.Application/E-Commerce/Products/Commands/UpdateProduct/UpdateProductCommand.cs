using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Products.Dtos;

namespace Solidify.Application.E_Commerce.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : UpdateProductDto, IRequest<GeneralResponseDto>
    {
        public string Id { get; set; }
    }
}
