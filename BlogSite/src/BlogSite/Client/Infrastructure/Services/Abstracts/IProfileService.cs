using BlogSite.Shared.Dtos;

namespace BlogSite.Client.Infrastructure.Services.Abstracts
{
    public interface IProfileService
    {
        Task<UserInfoDTO> UserProfile();
        Task<string> UserRole();
    }
}
