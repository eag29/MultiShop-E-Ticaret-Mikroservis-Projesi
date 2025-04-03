using _MultiShop.DtoLayer.BasketDtos;
using _MultiShop.WebUI.Services.BasketServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using _MultiShop.WebUI.Services.DiscountServcies;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;

        public ShoppingCartController(IProductService productService, IBasketService basketService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _discountService = discountService;
        }
        public async Task<IActionResult> Index(string Code, int discountRate, decimal fiyat)
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            ViewBag.Code = Code;
            ViewBag.discountRate = discountRate;
            ViewBag.fiyat = fiyat;

            var Tutar = await _basketService.GetBasket();
            ViewBag.tutar = Tutar.TotalPrice;

            var kdvTutar = Tutar.TotalPrice * 10 / 100;
            ViewBag.kdv = kdvTutar;

            var toplamTutar = Tutar.TotalPrice + kdvTutar;
            ViewBag.ToplamTutar = toplamTutar;

            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
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


            var values = await _discountService.GetDiscountCode(code);

            var basketValues = await _basketService.GetBasket();
            var toplamTutar = basketValues.TotalPrice + basketValues.TotalPrice * 10 / 100;

            var indirimliFiyat = toplamTutar - (toplamTutar / 100 * basketValues.DiscountRate);
            ViewBag.fiyat = indirimliFiyat;

            return RedirectToAction("Index", "ShoppingCart", new { Code = code, discountRate = basketValues.DiscountRate });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCartSummary()
        {
            var basketValues = await _basketService.GetBasket();

            if (basketValues == null)
            {
                return Json(new { success = false, message = "Sepet bulunamadı." });
            }

            decimal toplamTutar = basketValues.TotalPrice + (basketValues.TotalPrice * 0.10m); // KDV dahil toplam
            decimal discountRate = basketValues.DiscountRate; // Sepetteki indirim oranı
            decimal indirimliFiyat = toplamTutar - (toplamTutar * discountRate / 100); // İndirim uygulanmış fiyat

            return Json(new
            {
                success = true,
                toplamTutar = toplamTutar.ToString("0.00"),
                kdv = (toplamTutar * 0.10m).ToString("0.00"),
                discountRate = discountRate.ToString("0.00"),
                toplamTutarIndirimli = indirimliFiyat.ToString("0.00")
            });
        }

    }
}
