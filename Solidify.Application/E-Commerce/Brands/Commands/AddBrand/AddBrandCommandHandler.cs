using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.E_Commerce.Categories.Commands;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Commands.AddBrand
{
    public class AddBrandCommandHandler(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<AddBrandCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name = request.Name
               
            };

            unitOfWork.GetRepository<Brand>().AddAsync(brand);
            await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            var BrandUri = $"{baseUri}/api/Category/{brand.Id}";
            return GeneralResponse.CreateResponse(true, 201, BrandUri, "");
        }
    }
}
