using _MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ICatalogStatisticService _catalogStatisticService;

        public _CategoriesDefaultComponentPartial(ICategoryService categoryService, ICatalogStatisticService catalogStatisticService)
        {
            _categoryService = categoryService;
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            var productCount = await _catalogStatisticService.GetProductCount();
            ViewBag.ProductCount = productCount;
            return View(values);
        }
    }
}
