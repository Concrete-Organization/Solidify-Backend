using AutoMapper;
using Solidify.Application.Companies.Dtos;
using Solidify.Domain.Entities.ECommerce.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.Companies.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<ConcreteCompany, GetCompanyDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));


            CreateMap<UpdateCompanyDto, ConcreteCompany>();


            //CreateMap<ConcreteCompany, UpdateCompanyDto>()
            //     .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));




                 //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                 //.ReverseMap();
                 

        }
    }
}
