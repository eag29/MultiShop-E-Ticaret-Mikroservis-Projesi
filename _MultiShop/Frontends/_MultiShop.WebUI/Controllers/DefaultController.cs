using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Ana Sayfa";
            ViewBag.directory2 = "Ürün Listesi";
            return View();
        }
    }
}
