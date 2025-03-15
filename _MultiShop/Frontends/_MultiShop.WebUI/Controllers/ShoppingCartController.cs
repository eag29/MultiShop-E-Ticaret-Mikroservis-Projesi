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

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string Code,int discountRate, decimal fiyat)
        {
            ViewBag.Code = Code;
            ViewBag.discountRate = discountRate;
            ViewBag.fiyat = fiyat;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;

            var toplamTutar = values.TotalPrice + values.TotalPrice * 10 / 100;
            ViewBag.ToplamTutar = toplamTutar;

            var kdvTutar = values.TotalPrice * 10 / 100;
            ViewBag.kdv = kdvTutar;

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
    }
}
