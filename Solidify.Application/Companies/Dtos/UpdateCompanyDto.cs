using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Dtos
{
    public class UpdateCompanyDto
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public IFormFile? ProfileImageUrl { get; set; }
        public IFormFile? CoverImageUrl { get; set; }
        public string? Bio { get; set; }
    }
}
