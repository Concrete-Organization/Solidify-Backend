using MediatR;
using Microsoft.AspNetCore.Http;
using Solidify.Application.Accounts.Commands.Register;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Commands.Register
{
    public class RegisterCompanyCommand : RegisterUserCommand ,IRequest<GeneralResponseDto>
    {
        [MinLength(3)]
        [Required]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Address { get; set; }

        //   public string Address { get; set; }
        public string CommericalNumber { get; set; }
        public long TaxId { get; set; }
        public IFormFile CommericalLicense { get; set; }

      //  public string UserName { get; set; }
      //  public string Email { get; set; }
     //   public string Password { get; set; }
       // [Compare("Password")]
       // [Required]
       // [DataType(DataType.Password)]
       //// public string ConfirmPassword { get; set; }
       // public string PhoneNumber { get; set; }

    }
}
