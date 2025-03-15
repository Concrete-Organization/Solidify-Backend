using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.BrandSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateBrandCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandRepo = unitOfWork.GetRepository<Brand>();
            var brand = await brandRepo.GetAsync(new BrandSpecifications(request.Id))
            ?? throw new NotFoundException(nameof(Brand), request.Id);

            brand.Name = request.Name;
            brandRepo.Update(brand);

            await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, 200, null, $"new name is {brand.Name}");

        }
    }
}
