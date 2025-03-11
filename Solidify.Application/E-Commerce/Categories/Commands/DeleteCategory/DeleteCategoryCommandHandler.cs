using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRepo =  unitOfWork.GetRepository<Category>();
                var category = await  categoryRepo.GetAsync(new CategorySpecifications(request.Id)) 
                ?? throw new NotFoundException(nameof(Category),request.Id);

            categoryRepo.Delete(category);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true,200, null, $"Category with id [{request.Id}] deleted successfully");

        }
    }
}
