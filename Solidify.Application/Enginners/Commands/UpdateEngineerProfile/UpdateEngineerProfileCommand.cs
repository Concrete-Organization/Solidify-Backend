using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Enginners.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Commands.UpdateEngineerProfile
{
    public class UpdateEngineerProfileCommand : UpdateEngineerDto, IRequest<GeneralResponseDto>
    {
        public string Id { get; set; } 

    }
}
