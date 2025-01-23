using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Files
{
    public interface IFileService
    {
        Task<GeneralResponseDto> UploadFileAsync(IFormFile file,string fileType);

    }
}
