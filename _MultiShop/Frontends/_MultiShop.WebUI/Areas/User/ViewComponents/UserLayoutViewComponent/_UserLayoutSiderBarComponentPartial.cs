using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutSiderBarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
