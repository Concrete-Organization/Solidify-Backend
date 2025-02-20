using AutoMapper;
using Solidify.Application.E_Commerce.Categories.Dtos;
using Solidify.Application.E_Commerce.Categories.Query.GetAllCategories;
using Solidify.Application.E_Commerce.Products.Resolvers;
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
            CreateMap<GetAllCategoriesQuery, CategorySpecificationsParameters>();
            CreateMap<Category, CategoryDto>(); 
            CreateMap<Category,AllCategoriesDto>();
        }
    }
}
