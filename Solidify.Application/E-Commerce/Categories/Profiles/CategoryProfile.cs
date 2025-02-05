using AutoMapper;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Application.E_Commerce.Categories.Queries.GetAllCategories;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoriesDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<GetAllCategoriesQuery, CategorySpecificationParameters>();

        }
    }
}
