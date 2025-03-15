using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListColorFilterViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
