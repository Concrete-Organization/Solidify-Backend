using MediatR;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand(int id) : IRequest<GeneralResponseDto>
    {
        public int Id { get; } = id;
    }
}
