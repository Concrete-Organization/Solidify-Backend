using AutoMapper;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Helper;
using Solidify.Application.Community.Posts.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Comments.CommentProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom<ProfileImageUriResolver<Comment, CommentDto>>())
                .ForMember(dest => dest.EngineerName, opt => opt.MapFrom<EngineerNameResolver<Comment, CommentDto>>());
        }
    }
}
