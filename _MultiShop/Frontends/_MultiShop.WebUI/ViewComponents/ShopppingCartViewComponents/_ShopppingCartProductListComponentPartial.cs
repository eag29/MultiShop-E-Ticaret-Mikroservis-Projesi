using _MultiShop.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ShopppingCartViewComponents
{
    public class _ShopppingCartProductListComponentPartial: ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShopppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
