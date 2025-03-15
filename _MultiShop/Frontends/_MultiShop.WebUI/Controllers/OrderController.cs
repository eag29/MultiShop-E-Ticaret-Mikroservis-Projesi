using _MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IuserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IuserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserID = values.Id;
            createOrderAddressDto.Description = "Açıklama";

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
