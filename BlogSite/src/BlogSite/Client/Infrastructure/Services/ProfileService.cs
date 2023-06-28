using BlogSite.Client.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using BlogSite.Shared.Dtos;
using System.Security.Claims;

namespace BlogSite.Client.Infrastructure.Services
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _http;

        private readonly AuthenticationStateProvider _authenticationStateTask;

        public ProfileService(HttpClient http, AuthenticationStateProvider authenticationStateTask)
        {
            _http = http;
            _authenticationStateTask = authenticationStateTask;
        }

        public async Task<UserInfoDTO> UserProfile()
        {
            var authState = await _authenticationStateTask.GetAuthenticationStateAsync();
            var userId = authState.User.FindFirst("id").Value;
            var xx = authState.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;

            Console.WriteLine($"userId => {userId}");
            if (authState.User.Identity.IsAuthenticated)
            {
                return await _http.GetFromJsonAsync<UserInfoDTO>($"api/profile/getUserById/{userId}");
            }
            else
            {
                return null;
            }
        }

        public async Task<string> UserRole()
        {
            var authState = await _authenticationStateTask.GetAuthenticationStateAsync();
            var userId = authState.User.FindFirst("id").Value;
            return await _http.GetFromJsonAsync<string>($"api/profile/getUserRoleById/{userId}");
        }

    }
}
