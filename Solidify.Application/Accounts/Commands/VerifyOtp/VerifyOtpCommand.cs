using MediatR;
using Solidify.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Application.Accounts.Commands.VerifyOtp
{
    public class VerifyOtpCommand : IRequest<GeneralResponseDto>
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Otp { get; set; }
    }
}
