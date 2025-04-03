using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _AllProductListComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;

        public _AllProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
