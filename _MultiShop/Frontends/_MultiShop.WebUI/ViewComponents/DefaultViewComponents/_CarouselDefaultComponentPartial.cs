using _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos;
using _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
