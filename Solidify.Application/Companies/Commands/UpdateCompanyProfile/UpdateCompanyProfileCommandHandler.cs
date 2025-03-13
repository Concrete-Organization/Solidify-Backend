using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CompanySpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Commands.UpdateCompanyProfile
{
    public class UpdateCompanyProfileCommandHandler(IMapper mapper,
        IUnitOfWork unitOfWork,
        IFileService fileService,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateCompanyProfileCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UpdateCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            var repository =  unitOfWork.GetRepository<ConcreteCompany>();
            var company = await repository.GetAsync(new CompanySpecification(request.Id))
                ?? throw new NotFoundException(nameof(ConcreteCompany), request.Id);
            

            if(request.ProfileImageUrl != null)
            {
               var profileImg = await fileService.UploadFileAsync(request.ProfileImageUrl, FileType.Company);

                if (!profileImg.IsSucceeded)
                {
                    return profileImg;
                }
                    
                if(company.ProfileImageUrl is not null) 
                     fileService.DeleteFile(company.ProfileImageUrl, FileType.Company);

                company.ProfileImageUrl = profileImg.Model.ToString();
            }

            if (request.CoverImageUrl != null)
            {
                var coverImg = await fileService.UploadFileAsync(request.CoverImageUrl, FileType.Company);

                if (!coverImg.IsSucceeded)
                {
                    return coverImg;
                }

                if (company.CoverImageUrl is not null)
                    fileService.DeleteFile(company.CoverImageUrl, FileType.Company);

                company.CoverImageUrl = coverImg.Model.ToString();
            }

            mapper.Map(request, company);

            repository.Update(company);
            await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            var companyUri = $"{baseUri}/api/companyProfile/{company.ConcreteCompanyId}";

            return GeneralResponse.CreateResponse(true, 201, companyUri, "Company Updated Successfully");
        }
    }
}
