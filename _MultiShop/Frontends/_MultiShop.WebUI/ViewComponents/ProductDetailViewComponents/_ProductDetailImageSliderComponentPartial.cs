using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using _MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailImageSliderComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }
    }
}
