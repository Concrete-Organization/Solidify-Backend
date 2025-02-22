using AutoMapper;
using Solidify.Application.Community.Comments.Dtos;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Comments.CommentProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
