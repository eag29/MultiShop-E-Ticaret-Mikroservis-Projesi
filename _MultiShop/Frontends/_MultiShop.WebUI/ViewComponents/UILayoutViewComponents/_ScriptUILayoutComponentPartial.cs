using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
