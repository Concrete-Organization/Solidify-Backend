using MediatR;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Queries.GetEngineerQuery
{
    public class GetEngineerQuery(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
