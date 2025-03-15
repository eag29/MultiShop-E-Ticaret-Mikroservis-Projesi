using _MultiShop.WebUI.Models;
using _MultiShop.WebUI.Services.Interfaces;

namespace _MultiShop.WebUI.Services.Concrete
{
    public class UserService : IuserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}
