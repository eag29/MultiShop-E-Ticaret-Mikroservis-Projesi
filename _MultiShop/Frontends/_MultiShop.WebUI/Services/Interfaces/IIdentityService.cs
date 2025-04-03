using _MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace _MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto identity);
        Task Logout();
        Task<bool> GetRefreshToken();
    }
}
