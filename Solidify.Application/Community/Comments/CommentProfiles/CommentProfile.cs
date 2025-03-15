using AutoMapper;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Comments.Resolvers;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Application.Community.Posts.Resolvers;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Comments.CommentProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom<CommentProfileImageUriResolver>())
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom(src => src.Engineer.EngineerName))
                .ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.Replies))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count()))
                .ForMember(dest => dest.IsLiked, opt => opt.MapFrom<CommentIsLikedResolver>());
        }
    }
}
