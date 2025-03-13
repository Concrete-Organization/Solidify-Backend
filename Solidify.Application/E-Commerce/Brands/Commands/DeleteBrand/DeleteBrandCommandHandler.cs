using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common;
using Solidify.Application.E_Commerce.Categories.Commands.DeleteCategory;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Specification.BrandSpecifications;

namespace Solidify.Application.E_Commerce.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBrandCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brandRepo = unitOfWork.GetRepository<Brand>();
            var brand = await brandRepo.GetAsync(new BrandSpecifications(request.Id))
            ?? throw new NotFoundException(nameof(Brand), request.Id);

            brandRepo.Delete(brand);
            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, 200, null, $"Brand with id [{request.Id}] deleted successfully");

        }

    }
}
