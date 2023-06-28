using AutoMapper;
using BlogSite.Entities;
using BlogSite.Shared.Dtos;

namespace BlogSite.Service.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();
        }
    }
}
