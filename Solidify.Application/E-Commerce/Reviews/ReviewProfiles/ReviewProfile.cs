using AutoMapper;
using Solidify.Application.E_Commerce.Reviews.Dtos;
using Solidify.Application.E_Commerce.Reviews.Resolvers;
using Solidify.Domain.Entities.Common;
using Solidify.Domain.Entities.ECommerce;

namespace Solidify.Application.E_Commerce.Reviews.ReviewProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ProductReview, ReviewDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.ConcreteCompany.CompanyName))
                .ForMember(dest => dest.ProfileImageUrl,
                    opt => opt.MapFrom<ReviewCompanyImageUriResolver>());
        }
    }
}
