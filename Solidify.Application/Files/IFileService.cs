using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;
using Solidify.Domain.Enums;

namespace Solidify.Application.Files
{
    public interface IFileService
    {
        Task<GeneralResponseDto> UploadFileAsync(IFormFile file,FileType fileType);

    }
}
