using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Files
{
    public class FileService : IFileService
    {
        public async Task<GeneralResponseDto> UploadFileAsync(IFormFile file,string fileType)
        {
            //extentions
            List<string> validExtentions = new List<string>() { ".jpg", ".pdf", ".png" };
            string extention = Path.GetExtension(file.FileName.ToLower());

            if (!validExtentions.Contains(extention))
            {
                return new GeneralResponseDto
                {
                    Message = $"Extention is not valid ({string.Join(',', validExtentions)})",
                    StatusCode = 400,
                    IsSucceeded = false,
                };
            }


            //file size
            long size = file.Length;
            if (size > 5 * 1024 * 1024)
            {
                return new GeneralResponseDto
                {
                    Message = "Maximum size can be 5mb",
                    StatusCode = 400,
                    IsSucceeded = false,
                };
            }

            //name changing
            string fileName = Guid.NewGuid().ToString() + extention;

            string folderName = fileType.ToLower() switch
            {
                "cv" => "CVs",
                "license" => "Licenses",
                "syndicatecard" => "SyndicateCards",
                _ => "Others"
            };


            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", folderName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new GeneralResponseDto
            {
                IsSucceeded = true,
                StatusCode = 200,
                Model = fileName
            };
        }
    }
}
