﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Commands.UpdateBrand
{
    public class UpdateCategoryCommand(int id) : IRequest<GeneralResponseDto>
    {
        [FromRoute]
        public int Id { get; } = id;
        public string Name { get; set; }
    }
}
