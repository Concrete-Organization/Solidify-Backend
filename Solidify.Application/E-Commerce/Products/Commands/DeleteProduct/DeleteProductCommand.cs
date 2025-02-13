using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
