using MediatR;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Queries.GetCompanyQuery
{
    public class GetCompanyQuery : IRequest<GeneralResponseDto>
    {
    }
}
