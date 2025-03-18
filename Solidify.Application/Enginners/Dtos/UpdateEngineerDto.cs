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
        public IFormFile? ProfileImageUrl { get; set; }
    }
}
