using Microsoft.AspNetCore.Http;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidify.Application.Common;
using Solidify.Domain.Enums;
using Solidify.Domain.Exceptions;
using Solidify.Domain.Constants;

namespace Solidify.Application.Files
{
    public class FileService : IFileService
    {
        public async Task<GeneralResponseDto> UploadFileAsync(IFormFile file,FileType fileType)
        {
            var validationResult = ValidateFile(file);
            if (validationResult != null)
                return validationResult;

            //name changing
            string extention = Path.GetExtension(file.FileName.ToLower());
            string fileName = Guid.NewGuid().ToString() + extention;

            string folderName = GetFolderName(fileType);


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


        public GeneralResponseDto DeleteFile(string fileName, FileType fileType)
        {
            string folderName = GetFolderName(fileType);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", folderName);

            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
                return GeneralResponse.CreateResponse(false, StatusCodes.Status404NotFound, fileName,
                    $"{FileType.ProductImage.ToString()} [{fileName}] not found");

            File.Delete(filePath);
            return GeneralResponse.CreateResponse(true, StatusCodes.Status200OK, fileName,
                $"{FileType.ProductImage.ToString()} [{fileName}] deleted successfully");
        }


        private static GeneralResponseDto? ValidateFile(IFormFile file)
        {
            // Extensions
            List<string> validExtensions = new List<string>() { ".jpg", ".pdf", ".png" };
            string extension = Path.GetExtension(file.FileName.ToLower());

            if (!validExtensions.Contains(extension))
            {
                return new GeneralResponseDto
                {
                    Message = $"Extension is not valid ({string.Join(',', validExtensions)})",
                    StatusCode = 400,
                    IsSucceeded = false,
                };
            }

            // File size
            long size = file.Length;
            if (size > 5 * 1024 * 1024) // 5MB
            {
                return new GeneralResponseDto
                {
                    Message = "Maximum size can be 5MB",
                    StatusCode = 400,
                    IsSucceeded = false,
                };
            }

            return null; 
        }
        private static string GetFolderName(FileType fileType)
        {
            return fileType switch
            {
                FileType.License => FileFolders.Licenses,
                FileType.SyndicateCard => FileFolders.SyndicateCards,
                FileType.ProductImage => FileFolders.ProductImages,
                FileType.Engineer => FileFolders.Engineers,
                FileType.Company => FileFolders.Companies,
                _ => FileFolders.Others
            };
        }

    }
}
