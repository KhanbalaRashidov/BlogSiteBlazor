using BlogSite.Entities;
using System.Security.Claims;

namespace BlogSite.Service.Abstract
{
    public interface ITokenService
    {
        string GenerateAccessToken(List<Claim> claims);
        string GenerateRefreshToken();
        Task<List<Claim>> GetClaims(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
