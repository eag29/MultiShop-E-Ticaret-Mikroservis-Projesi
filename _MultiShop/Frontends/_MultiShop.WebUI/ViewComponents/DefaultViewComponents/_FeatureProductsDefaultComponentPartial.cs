using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService)
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
