using _MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using _MultiShop.WebUI.Services.CatalogServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIDProductDetailAsync(id);
            return View(values);
        }
    }
}
