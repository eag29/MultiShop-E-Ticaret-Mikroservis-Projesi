using _MultiShop.DtoLayer.CatalogDtos.FeaureDtos;
using _MultiShop.WebUI.Services.CatalogServices.FeatureService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial: ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
