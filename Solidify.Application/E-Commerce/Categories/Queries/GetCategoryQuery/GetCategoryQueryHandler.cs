using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Categories.Dtos;
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

            return GeneralResponse.CreateResponse(true, 200, mapper.Map<CategoryDto>(category), "");
        }
    }
}
