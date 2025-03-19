using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Files;
using Solidify.Domain.Entities;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Interfaces;
using Solidify.Domain.Specification.EngineerSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Commands.DeleteEngineerProfile
{
    public class DeleteEngineerProfileCommandHandler(IUnitOfWork unitOfWork
        , IFileService fileService) : IRequestHandler<DeleteEngineerProfileCommand, GeneralResponseDto>
    {
        public async Task<GeneralResponseDto> Handle(DeleteEngineerProfileCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Engineer>();
            var eng = await repository.GetAsync(new EngineerSpecification(request.Id))
                ?? throw new NotFoundException(nameof(Engineer), request.Id);


                if (eng.ProfileImageUrl is not null)
                    fileService.DeleteFile(eng.ProfileImageUrl, FileType.Engineer);

            eng.ProfileImageUrl = null;
             await unitOfWork.Commit();

            return GeneralResponse.CreateResponse(true, 201, null, "Profile Picture Deleted Successfully");

        }
    }
}
