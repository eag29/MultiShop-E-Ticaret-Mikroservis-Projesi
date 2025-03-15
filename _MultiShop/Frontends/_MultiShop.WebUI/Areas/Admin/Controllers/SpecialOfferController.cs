using _MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using _MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
        {
            _httpClientFactory = httpClientFactory;
            _specialOfferService = specialOfferService;
        }

        void SpecialOfferViewBaglist()
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewBaglist();
            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBaglist();
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);   
            return View(values);
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
