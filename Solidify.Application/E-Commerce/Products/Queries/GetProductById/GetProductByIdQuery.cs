using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.Products.Queries.GetProdocutById
{
    public class GetProductByIdQuery(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
