using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bakalarska_prace.Models.Auth;

namespace Bakalarska_prace.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7000/") };
        }

        public async Task<string?> LoginAsync(string aLogin, string aPassword)
        {
            var loginDto = new LoginRequestDto { Login = aLogin, Password = aPassword };
            var response = await _httpClient.PostAsJsonAsync("tady dát kam na server", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                return result?.Token;
            }
            return null;
        }

        public async Task<RegisterResponseDto?> RegisterAsync(string aUsername, string aPassword, string aEmail)
        {
            var registerDto = new RegisterRequestDto { Username = aUsername, Password = aPassword, Email = aEmail };
            var response = await _httpClient.PostAsJsonAsync($"tady dát kam na server", registerDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RegisterResponseDto>();
            }
            return null;
        }
    }
}