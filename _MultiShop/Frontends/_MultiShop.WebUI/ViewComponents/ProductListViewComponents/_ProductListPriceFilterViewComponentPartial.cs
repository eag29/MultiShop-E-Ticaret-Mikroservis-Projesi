using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPriceFilterViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
