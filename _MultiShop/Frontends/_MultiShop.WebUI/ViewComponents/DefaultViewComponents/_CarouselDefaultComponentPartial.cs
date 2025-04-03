using _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos;
using _MultiShop.WebUI.Models;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using _MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;
        private readonly ICatalogStatisticService _catalogStatisticService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService, ICatalogStatisticService catalogStatisticService)
        {
            _featureSliderService = featureSliderService;
            _catalogStatisticService = catalogStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            var featureslidercount = await _catalogStatisticService.GetFeatureSliderCount();
            ViewBag.featureSliderCount = featureslidercount;
            return View(values);
        }
    }
}
