using _MultiShop.WebUI.Services.BasketServices;
using _MultiShop.WebUI.Services.DiscountServcies;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {

            /*var values = await _discountService.GetDiscountCode(code);

            var basketValues = await _basketService.GetBasket();
            var toplamTutar = basketValues.TotalPrice + basketValues.TotalPrice * 10 / 100;
            var indirimliFiyat = toplamTutar - (toplamTutar / 100 * values.Rate);
            ViewBag.fiyat = indirimliFiyat;
            return RedirectToAction("Index", "ShoppingCart", new { Code = code });*/

          
            var values = await _discountService.GetDiscountCouponRate(code);

            var basketValues = await _basketService.GetBasket();
            var toplamTutar = basketValues.TotalPrice + basketValues.TotalPrice * 10 / 100;

            var indirimliFiyat = toplamTutar - (toplamTutar / 100 * values);
            //ViewBag.fiyat = indirimliFiyat;

            return RedirectToAction("Index", "ShoppingCart", new { Code = code, discountRate=values, fiyat=indirimliFiyat });
        }
    }
}
