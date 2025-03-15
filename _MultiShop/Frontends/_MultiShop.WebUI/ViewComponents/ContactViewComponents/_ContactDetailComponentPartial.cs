using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
