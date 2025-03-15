using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
