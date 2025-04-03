using _MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto;
using _MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfferDiscountService _offerDiscountService;
        private readonly IProductService _productService;

        public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService offerDiscountService, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _offerDiscountService = offerDiscountService;
            _productService = productService;
        }
        void OfferDiscountViewbagList()
        {
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewbagList();
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount()
        {
            OfferDiscountViewbagList();

            var values = await _productService.GetAllProductAsync();
            List<SelectListItem> productValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.ProductName,
                                                       Value = x.ProductID
                                                   }).ToList();
            ViewBag.ProductValues = productValues;

            return View();
        }
        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            OfferDiscountViewbagList();
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewbagList();
            var values = await _productService.GetAllProductAsync();
            List<SelectListItem> productValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ProductName,
                                                      Value = x.ProductID
                                                  }).ToList();
            ViewBag.ProductValues = productValues;

            var valuess = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(valuess);
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
