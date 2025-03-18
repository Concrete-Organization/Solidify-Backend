using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Enginners.Dtos;
using Solidify.Domain.Entities;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Domain.Specification.EngineerSpecifications;
using Microsoft.AspNetCore.Http;

namespace Solidify.Application.Enginners.Queries.GetEngineerQuery
{
    public class GetEngineerQueryHandler(IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetEngineerQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetEngineerQuery request, CancellationToken cancellationToken)
        {
            var engineer = await unitOfWork.GetRepository<Engineer>()
                .GetAsync(new EngineerSpecification(request.Id))
                    ?? throw new NotFoundException(nameof(Engineer), request.Id);
           
            var EngDto = mapper.Map<GetEngineerDto>(engineer);

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (engineer.ProfileImageUrl is not null)
                EngDto.ProfileImageUrl = $"{baseUri}/Uploads/Engineers/{EngDto.ProfileImageUrl}";




            return GeneralResponse.CreateResponse(true, 200, EngDto, "Engineer return successfully");
        }
    }
}
