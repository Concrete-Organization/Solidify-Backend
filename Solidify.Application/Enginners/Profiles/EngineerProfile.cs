using AutoMapper;
using Solidify.Application.Enginners.Dtos;
using Solidify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Enginners.Profiles
{
    public class EngineerProfile : Profile
    {
        public EngineerProfile()
        {
            CreateMap<Engineer, GetEngineerDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
