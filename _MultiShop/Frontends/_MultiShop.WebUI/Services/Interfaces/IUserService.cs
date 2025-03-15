using _MultiShop.WebUI.Models;

namespace _MultiShop.WebUI.Services.Interfaces
{
    public interface IuserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
