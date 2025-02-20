using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Query.GetAllCategories
{
    public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new CategorySpecifications(mapper.Map<CategorySpecificationsParameters>(request));


            var (categories,count) = await unitOfWork.GetRepository<Category>().GetAllAsync(spec);
            var categoriesDto = mapper.Map<IEnumerable<AllCategoriesDto>>(categories);

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, new PagedResponse<AllCategoriesDto>
                (categoriesDto,request.PageSize,request.PageNumber,count), "");
        }
    }
}
