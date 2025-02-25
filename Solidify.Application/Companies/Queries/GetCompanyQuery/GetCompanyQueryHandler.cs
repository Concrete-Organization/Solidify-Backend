using AutoMapper;
using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Companies.Dtos;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CompanySpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Queries.GetCompanyQuery
{
    public class GetCompanyQueryHandler(IMapper mapper,
        IUnitOfWork unitOfWork) : IRequestHandler<GetCompanyQuery, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var spec = new CompanySpecification(request.Id);
            var company = await unitOfWork.GetRepository<ConcreteCompany>().GetAsync(new CompanySpecification(request.Id))
                ?? throw new NotFoundException(nameof(ConcreteCompany), request.Id); 

            var companyDto = mapper.Map<GetCompanyDto>(company);
            return GeneralResponse.CreateResponse(true, 200, companyDto, "");
        }
    }
}
