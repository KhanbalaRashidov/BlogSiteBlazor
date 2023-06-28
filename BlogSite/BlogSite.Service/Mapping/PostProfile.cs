using AutoMapper;
using BlogSite.Entities;
using BlogSite.Shared.Dtos;

namespace BlogSite.Service.Mapping
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Post, AddPostDTO>().ReverseMap();
            CreateMap<Post, EditPostDTO>().ReverseMap();
        }
    }
}
