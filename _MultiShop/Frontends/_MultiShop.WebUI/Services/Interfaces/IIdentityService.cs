using _MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace _MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
