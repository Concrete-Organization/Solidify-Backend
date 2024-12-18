using MediatR;
using Solidify.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Application.Accounts.Commands.SendOtp
{
    public class SendOtpCommand : IRequest<GeneralResponseDto>
    {
        [DataType(DataType.EmailAddress)]
        [Required]

        public string Email { get; set; }
    }
}
