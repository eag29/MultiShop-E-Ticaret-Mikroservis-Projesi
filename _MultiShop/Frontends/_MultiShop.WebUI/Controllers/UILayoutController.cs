using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        private readonly ICategoryService _categoryService;

        public UILayoutController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> _UILayout()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
