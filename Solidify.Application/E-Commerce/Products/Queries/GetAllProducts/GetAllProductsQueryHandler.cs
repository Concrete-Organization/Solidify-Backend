using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.Services.Caching;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Interfaces.Services.Cashing;
using Solidify.Domain.Specification.ProductSpecifications;
using System.Collections.Generic;

namespace Solidify.Application.E_Commerce.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper,
        ICacheService cacheService)
        : IRequestHandler<GetAllProductsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var cacheResult = await cacheService.GetAsync(cacheService.GenerateCachedKeyFromRequest(), async () =>
            {
                var productRepository = unitOfWork.GetRepository<Product>();

                var (products, count) =
                    await productRepository.GetAllAsync(
                        new ProductsSpecification(mapper.Map<ProductSpecificationParameters>(request)));

                return new CacheResult<IEnumerable<ProductDto>>()
                    { Data = mapper.Map<IEnumerable<ProductDto>>(products), Count = count };
            }, TimeSpan.FromDays(1));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, new PagedResponse<ProductDto>(
                cacheResult.Data, request.PageSize,
                request.PageNumber, cacheResult.Count), "");
        }
    }
}
