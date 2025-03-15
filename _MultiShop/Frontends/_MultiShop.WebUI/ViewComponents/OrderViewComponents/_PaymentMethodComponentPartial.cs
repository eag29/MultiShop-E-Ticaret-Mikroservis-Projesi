using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
