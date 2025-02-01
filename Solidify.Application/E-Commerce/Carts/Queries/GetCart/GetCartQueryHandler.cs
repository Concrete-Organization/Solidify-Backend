using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Carts.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces.Services.Cashing;

namespace Solidify.Application.E_Commerce.Carts.Queries.GetCart
{
    public class GetCartQueryHandler(ICacheService cacheService,
        IMapper mapper) : IRequestHandler<GetCartQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await cacheService.GetAsync<Cart>("cart", () => Task.FromResult(new Cart()), TimeSpan.FromDays(15));
            
            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, mapper.Map<CartDto>(cart), "");
        }
    }
}
