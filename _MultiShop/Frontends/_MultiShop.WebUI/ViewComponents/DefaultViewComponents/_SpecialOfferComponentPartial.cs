using _MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using _MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
