using AutoMapper;
using Solidify.Application.Community.Posts.Resolvers;
using Solidify.Application.Community.Replies.Dtos;
using Solidify.Application.Community.Replies.Resolvers;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Replies.ReplyProfiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<Reply, ReplyDto>()
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom<ReplyProfileImageUriResolver>())
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom(src => src.Engineer.EngineerName))
                .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count()))
                .ForMember(dest => dest.IsLiked, opt => opt.MapFrom<ReplyIsLikedResolver>());
        }
    }
}
