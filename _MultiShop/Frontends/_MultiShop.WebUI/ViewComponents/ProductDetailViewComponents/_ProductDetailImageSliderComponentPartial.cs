using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using _MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIDImageAsync(id);
            return View(values);
        }
    }
}
