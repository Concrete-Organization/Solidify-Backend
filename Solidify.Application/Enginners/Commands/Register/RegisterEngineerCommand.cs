using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Accounts.Commands.Register;
using Solidify.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Application.Enginners.Commands.Register
{
    public class RegisterEngineerCommand :RegisterUserCommand ,IRequest<GeneralResponseDto>
    {
        //[MinLength(3)]
        //[Required]
        //public string UserName { get; set; }

        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(100, MinimumLength = 6)]
        //public string Password { get; set; }

        //[Compare("Password")]
        //[Required]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        ////[Required]
        ////public string PhoneNumber { get; set; }
        //[Required]
        //[MaxLength(250)]
        //public string? Address { get; set; }

    }
}
