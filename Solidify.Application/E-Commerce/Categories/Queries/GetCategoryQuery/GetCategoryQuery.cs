using MediatR;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Queries
{
    public class GetCategoryQuery(int id) : IRequest<GeneralResponseDto>
    {
        public int Id { get;  } = id;
    }
}
