using _MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using _MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _BrandDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandServices _brandServices;

        public _BrandDefaultComponentPartial(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values  = await _brandServices.GetAllBrandAsync();
            return View(values);
        }
    }
}
