using AutoMapper;
using BlogSite.Entities;
using BlogSite.Shared.Dtos;

namespace BlogSite.Service.Mapping
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>();
            CreateMap<Tag, AddTagDTO>().ReverseMap();
            CreateMap<Tag, UpdateTagDTO>().ReverseMap();
        }
    }
}

