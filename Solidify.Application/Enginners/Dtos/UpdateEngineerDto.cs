using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Dtos
{
    public class UpdateEngineerDto
    {
        public string UserName { get; set; }
        public string EngineerName { get; set; }
        public IFormFile? ProfileImageUrl { get; set; }
        public IFormFile? CoverImageUrl { get; set; }
        public string? Bio { get; set; }
    }
}
