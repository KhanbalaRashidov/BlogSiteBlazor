using AutoMapper;
using BlogSite.Entities;
using BlogSite.Shared.Dtos;

namespace BlogSite.Service.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserUpdateDTO>();
        }
    }
}

