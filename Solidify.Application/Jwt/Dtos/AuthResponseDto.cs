using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Jwt.Dtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        //public ApplicationUserRole UserRole { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
