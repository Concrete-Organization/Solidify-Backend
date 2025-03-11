using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Application.E_Commerce.Products.Queries.GetProdocutById;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.ProductSpecifications;

namespace Solidify.Application.E_Commerce.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper) 
    : IRequestHandler<GetProductByIdQuery, GeneralResponseDto>
{
    public async Task<GeneralResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var productRepository = unitOfWork.GetRepository<Product>();

        var product = await productRepository.GetAsync(new ProductsSpecification(request.Id))
                      ?? throw new NotFoundException(nameof(Product), request.Id);

        return GeneralResponse.CreateResponse(true, 200, mapper.Map<ProductDto>(product), "");
    }
}