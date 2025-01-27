using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Accounts.Commands.Register;
using Solidify.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Solidify.Application.Enginners.Commands.Register
{
    public class RegisterEngineerCommand :RegisterUserCommand ,IRequest<GeneralResponseDto>
    {
        
        [Required]
        public IFormFile CV { get; set; }

        [Required]
        public IFormFile SyndicateCard { get; set; }
    }
}
