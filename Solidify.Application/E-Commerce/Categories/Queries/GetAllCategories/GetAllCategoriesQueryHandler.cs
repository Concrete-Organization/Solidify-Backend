using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Application.E_Commerce.Products.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
        : IRequestHandler<GetAllCategoriesQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var spec = new CategorySpecification(mapper.Map<CategorySpecificationParameters>(request));

            var (categories, count) = await unitOfWork.GetRepository<Category>().GetAllAsync(spec);
          //  var model = await categories.GetAllAsync(spec);


           //var models =  new PagedResponse<ProductDto>(
           //     mapper.Map<IEnumerable<ProductDto>>(products), request.PageSize,
           //     request.PageNumber, count);


            return GeneralResponse.CreateResponse(true, 200,new PagedResponse<CategoriesDto>(
                mapper.Map<IEnumerable<CategoriesDto>>(categories),request.PageSize,request.PageNumber,count ), "");
        }
    }
}
