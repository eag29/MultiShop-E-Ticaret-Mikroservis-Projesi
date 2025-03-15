using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.User.Controllers
{
    public class UserLayoutController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
