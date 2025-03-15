using _MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto;
using _MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
