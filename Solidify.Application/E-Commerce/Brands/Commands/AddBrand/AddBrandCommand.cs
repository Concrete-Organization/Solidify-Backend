﻿using MediatR;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Commands.AddBrand
{
    public class AddBrandCommand : IRequest<GeneralResponseDto>
    {
        public string Name { get; set; }

    }
}
