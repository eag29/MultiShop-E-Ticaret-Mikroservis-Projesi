using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPaginationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
