using AutoMapper;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Application.Community.Posts.Queries.GetAllPosts;
using Solidify.Application.Community.Posts.Resolvers;
using Solidify.Domain.Entities.Community;
using Solidify.Domain.Specification.PostSpecifications;

namespace Solidify.Application.Community.Posts.PostProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.ImageUris, opt => opt.MapFrom<PostImagesUriResolver>());

            CreateMap<GetAllPostsQuery, PostSpecificationParameters>();
        }
    }
}
