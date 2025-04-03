using _MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using _MultiShop.WebUI.Services.CatalogServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailInformationComponentPartial(IProductService productService)
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
