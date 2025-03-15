using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListSizeFilterViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
