using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Queries
{
    public class GetCategoryQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<GetCategoryQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var spec = new CategorySpecifications(request.Id);

            var category = await unitOfWork.GetRepository<Category>().GetAsync(new CategorySpecifications(request.Id))
                ?? throw new NotFoundException(nameof(Category), request.Id);

            var totalProducts = category.Products.Count();
            var pagedProducts = category.Products
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var products = mapper.Map<IEnumerable<ProductDto>>(pagedProducts);

            var result = new PagedResponse<ProductDto>(products, request.PageSize, request.PageNumber, category.Products.Count());


            return GeneralResponse.CreateResponse(true, 200, new {category.Name, result}, "");
        }
    }
}
