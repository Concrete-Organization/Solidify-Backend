using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Domain.Entities;
using Solidify.Domain.Entities.ECommerce.Companies;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.CompanySpecification;
using Solidify.Domain.Specification.EngineerSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Commands.UpdateEngineerProfile
{
    public class UpdateEngineerProfileCommandHandler(IUnitOfWork unitOfWork
        , IFileService fileService
        , IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateEngineerProfileCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(UpdateEngineerProfileCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Engineer>();
            var eng = await repository.GetAsync(new EngineerSpecification(request.Id))
                ?? throw new NotFoundException(nameof(Engineer), request.Id);


            if (request.ProfileImageUrl != null)
            {
                var profileImg = await fileService.UploadFileAsync(request.ProfileImageUrl, FileType.Engineer);

                if (!profileImg.IsSucceeded)
                {
                    return profileImg;
                }

                if (eng.ProfileImageUrl is not null)
                    fileService.DeleteFile(eng.ProfileImageUrl, FileType.Engineer);

                eng.ProfileImageUrl = profileImg.Model.ToString();
            }

            repository.Update(eng);
            await unitOfWork.Commit();

            var httpContext = httpContextAccessor.HttpContext;
            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            // var companyUri = $"{baseUri}/api/companyProfile/{company.ConcreteCompanyId}";

            return GeneralResponse.CreateResponse(true, 201, baseUri, "Profile Updated Successfully");
        }
    }
}
