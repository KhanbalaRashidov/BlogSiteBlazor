using BlogSite.Shared.Identity.Account;

namespace BlogSite.Client.Infrastructure.Services.Abstracts
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task Logout();
        Task<string> RefreshToken();
    }
}
