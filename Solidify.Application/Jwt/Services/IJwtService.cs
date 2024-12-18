using Solidify.Application.Jwt.Dtos;
using Solidify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Jwt.Services
{
    public interface IJwtService
    {
        public AuthResponseDto GenerateToken(ApplicationUser user, IList<string> roles);
        //   bool ValidateToken(string token);
    }
}
