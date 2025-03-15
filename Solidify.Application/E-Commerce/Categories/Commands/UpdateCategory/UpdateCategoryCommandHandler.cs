using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common;
using Solidify.Application.E_Commerce.Brands.Commands.UpdateBrand;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.BrandSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Specification.CategorySpecifications;

namespace Solidify.Application.E_Commerce.Categories.Commands.UpdateBrand
{
    public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRepo = unitOfWork.GetRepository<Category>();
            var category = await categoryRepo.GetAsync(new CategorySpecifications(request.Id))
            ?? throw new NotFoundException(nameof(Category), request.Id);

            category.Name = request.Name;
            categoryRepo.Update(category);

            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, 200, null, $"new name is {category.Name}");

        }
    }
}
