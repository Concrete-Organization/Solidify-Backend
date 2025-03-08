using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Commands
{
    public class AddCategotyCommandHandler(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<AddCategotyCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(AddCategotyCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };

            unitOfWork.GetRepository<Category>().AddAsync(category);
             await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            var CategoryUri = $"{baseUri}/api/Category/{category.Id}";
            return GeneralResponse.CreateResponse(true, 201, CategoryUri, "");

        }
    }
}
