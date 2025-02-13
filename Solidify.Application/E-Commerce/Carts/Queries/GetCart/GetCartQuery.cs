using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Carts.Dtos;

namespace Solidify.Application.E_Commerce.Carts.Queries.GetCart
{
    public class GetCartQuery : IRequest<GeneralResponseDto>
    {
    }
}
