using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Dtos
{
    public class GetCompanyDto
    {
        public string? ProfileImageUrl { get; set; }
        public string UserName { get; set; }
        public string? EngineerName { get; set; }
        public string? Bio { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
