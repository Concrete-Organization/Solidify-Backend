using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Common.Dtos
{
    public class GeneralResponseDto
    {
        public bool IsSucceeded { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Model { get; set; }
    }
}
