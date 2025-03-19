using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Commands.DeleteEngineerProfile
{
    public class DeleteEngineerProfileCommand(string id) : IRequest<GeneralResponseDto>
    {
        [FromRoute]
        public string Id { get; } = id;
    }
}
