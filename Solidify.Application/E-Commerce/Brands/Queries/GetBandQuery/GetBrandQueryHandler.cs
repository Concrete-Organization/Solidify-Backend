using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.BrandSpecifications;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Queries.GetBandQuery
{
    public class GetBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetBrandQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var spec = new BrandSpecifications(request.Id);

            var brand = await unitOfWork.GetRepository<Brand>().GetAsync(new BrandSpecifications(request.Id))
                ?? throw new NotFoundException(nameof(Brand), request.Id);

            var totalProducts = brand.Products.Count();
            var pagedProducts = brand.Products
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var products = mapper.Map<IEnumerable<ProductDto>>(pagedProducts);

            var result = new PagedResponse<ProductDto>(products, request.PageSize, request.PageNumber, brand.Products.Count());


            return GeneralResponse.CreateResponse(true, 200, new { brand.Name, result }, "");
        }
    }
}
