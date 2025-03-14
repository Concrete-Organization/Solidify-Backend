﻿using Solidify.Application.Community.Comments.Dtos;
using Solidify.Application.Community.Helper;
using Solidify.Domain.Entities.Community;

namespace Solidify.Application.Community.Posts.Dtos
{
    public class PostDto : EngineerInfo
    {
        public DateTime CreationDate { get; set; }
        public string? Content { get; set; }
        public List<string> ImageUris { get; set; }
        public int LikesCount { get; set; }
        public bool IsLiked { get; set; }
        public int CommentsCount { get; set; }
    }
}
