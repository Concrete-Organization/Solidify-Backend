using MediatR;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Companies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Commands.UpdateCompanyProfile
{
    public class UpdateCompanyProfileCommand : UpdateCompanyDto , IRequest<GeneralResponseDto>
    {
        public string Id { get; set; }
    }
}
