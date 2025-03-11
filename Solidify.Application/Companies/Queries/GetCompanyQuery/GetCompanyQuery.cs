using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.Companies.Queries.GetCompanyQuery
{
    public class GetCompanyQuery(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
