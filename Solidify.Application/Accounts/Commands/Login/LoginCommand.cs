using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Jwt.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Accounts.Commands.Login
{
    public class LoginCommand : IRequest<GeneralResponseDto>
    {
        [Required]  
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
