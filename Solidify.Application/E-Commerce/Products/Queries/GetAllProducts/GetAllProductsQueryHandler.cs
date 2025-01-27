using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
        : IRequestHandler<GetAllProductsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productRepository = unitOfWork.GetRepository<Product>();

            var (products, count) =
                await productRepository.GetAllAsync(
                    new ProductsSpecification(mapper.Map<ProductSpecificationParameters>(request)));

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, new PagedResponse<ProductDto>(
                mapper.Map<IEnumerable<ProductDto>>(products), request.PageSize,
                request.PageNumber, count), "");
        }
    }
}
