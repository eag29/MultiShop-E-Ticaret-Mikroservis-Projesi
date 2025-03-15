using _MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace _MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavBarUILayoutComponentPartial: ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavBarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
