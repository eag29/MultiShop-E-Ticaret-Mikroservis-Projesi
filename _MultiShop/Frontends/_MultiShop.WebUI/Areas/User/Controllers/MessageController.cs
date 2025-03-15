using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
