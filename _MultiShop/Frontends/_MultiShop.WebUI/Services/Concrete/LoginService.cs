using _MultiShop.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace _MultiShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserID => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    }
}
