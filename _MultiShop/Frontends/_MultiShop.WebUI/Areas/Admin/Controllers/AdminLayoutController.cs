using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
