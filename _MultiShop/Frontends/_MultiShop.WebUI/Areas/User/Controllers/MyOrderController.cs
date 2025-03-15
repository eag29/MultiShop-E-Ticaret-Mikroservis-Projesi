using _MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;
using Microsoft.AspNetCore.Mvc;
namespace _MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IuserService _userService;


        public MyOrderController(IOrderOrderingService orderOrderingService, IuserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOrderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}

