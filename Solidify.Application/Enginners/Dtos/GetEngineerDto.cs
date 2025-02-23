using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Dtos
{
    public class GetEngineerDto
    {
        public string? ProfileImageUrl { get; set; }
        public string UserName { get; set; }
        public string? EngineerName { get; set; }
        public string? Bio { get; set; }
        public string? CoverImageUrl { get; set; }

    }
}
