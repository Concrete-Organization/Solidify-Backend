using MediatR;
using Solidify.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Application.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<GeneralResponseDto>
    {
        [DataType(DataType.EmailAddress)]
        [Required]

        public string Email { get; set; }

        [Required]
        public string Otp { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
