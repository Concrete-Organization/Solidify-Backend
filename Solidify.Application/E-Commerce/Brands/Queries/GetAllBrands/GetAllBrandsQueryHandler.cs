using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using Solidify.Application.E_Commerce.Brands.Dtos;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.BrandSpecifications;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Queries
{
    public class GetAllBrandsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<GetAllBrandsQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var spec = new BrandSpecifications(mapper.Map<BrandSpecificationsParameters>(request));

          

            var (brands, count) = await unitOfWork.GetRepository<Brand>().GetAllAsync(spec);
            var brandsDto = mapper.Map<IEnumerable<AllBrandsDto>>(brands);

            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, new PagedResponse<AllBrandsDto>
                (brandsDto, request.PageSize, request.PageNumber, count), "");
        }
    }
}
