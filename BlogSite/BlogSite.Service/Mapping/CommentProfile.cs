using AutoMapper;
using BlogSite.Entities;
using BlogSite.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, ReplyDTO>()
                .ForMember(dst => dst.ReplyId, _ => _.MapFrom(src => src.ReplyId));
            CreateMap<Comment, CommentDTO>()
                .ForMember(dst => dst.Replies, _ => _.MapFrom(src => src.Replies));
            CreateMap<Comment, AddCommentDTO>().ReverseMap();
            CreateMap<Comment, EditCommentDTO>().ReverseMap();
            CreateMap<Comment, AddReplyDTO>().ReverseMap();
        }
    }
}

