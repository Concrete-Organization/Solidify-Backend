using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Enginners.Dtos;
using Solidify.Domain.Entities;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.EngineerSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Queries.GetEngineerQuery
{
    public class GetEngineerQueryHandler(IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<GetEngineerQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetEngineerQuery request, CancellationToken cancellationToken)
        {
            var engSpec = new EngineerSpecification(request.Id);
            var engineer = await unitOfWork.GetRepository<Engineer>().GetAsync(engSpec); 
            var EngDto = mapper.Map<GetEngineerDto>(engineer);

            return GeneralResponse.CreateResponse(true, 200, EngDto, "Engineer return successfully");
        }
    }
}
