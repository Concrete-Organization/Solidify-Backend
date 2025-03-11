using AutoMapper;
using Solidify.Application.E_Commerce.Brands.Dtos;
using Solidify.Application.E_Commerce.Brands.Queries;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Application.E_Commerce.Categories.Query.GetAllCategories;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Specification.BrandSpecifications;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsQuery, BrandSpecificationsParameters>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Brand, AllBrandsDto>();
        }
    }
}
