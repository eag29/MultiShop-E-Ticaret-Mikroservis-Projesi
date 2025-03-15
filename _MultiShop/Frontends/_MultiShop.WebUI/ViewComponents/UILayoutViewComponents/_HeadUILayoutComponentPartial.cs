using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace _MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
