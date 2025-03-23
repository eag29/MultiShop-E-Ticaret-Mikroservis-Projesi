using _MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using _MultiShop.WebUI.Services.StatisticServices.CommentServices;
using _MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using _MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using _MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _catalogStatisticService.GetCategoryCount();
            ViewBag.v1 = values;

            var values2 = await _catalogStatisticService.GetProductCount();
            ViewBag.v2 = values2;

            var values3 = await _catalogStatisticService.GetBrandCount();
            ViewBag.v3 = values3;

            var values4 = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.v4 = values4;

            var values5 = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.v5 = values5;

            //var values6 = await _catalogStatisticService.GetProductAvgPrice();
            //ViewBag.v6 = values6;

            var values7 = await _userStatisticService.GetUserCount();
            ViewBag.v7 = values7;

            var values8 = await _commentStatisticService.GetTotalCommentCount();
            ViewBag.v8 = values8;

            var values9 = await _commentStatisticService.GetActiveCommentCount();
            ViewBag.v9 = values9;

            var values10 = await _commentStatisticService.GetPassiveCommentCount();
            ViewBag.v10 = values10;

            var values11 = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.v11 = values11;

            var values12 = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.v12 = values12;

            return View();
        }
    }
}
