using _MultiShop.WebUI.Services.CargoServices.CargoCustomerService;
using _MultiShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IuserService _userService;


        public UserController(IuserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }
    }
}
