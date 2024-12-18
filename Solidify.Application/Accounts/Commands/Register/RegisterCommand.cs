using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Jwt.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Accounts.Commands.Register
{
    public class RegisterCommand :IRequest<GeneralResponseDto>
    {
        [MinLength(3)]
        [Required]

        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
