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
                .ForMember(dest => dest.ImageUris, opt => opt.MapFrom<PostImagesUriResolver>())
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom(src => src.Engineer.EngineerName))
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom<PostProfileImageUriResolver>())
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count()))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count()));
            CreateMap<GetAllPostsQuery, PostSpecificationParameters>();
        }
    }
}
