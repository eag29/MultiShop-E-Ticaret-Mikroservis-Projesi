using _MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using _MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;

        public AboutController(IHttpClientFactory httpClientFactory, IAboutService aboutService)
        {
            _httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }
        void AboutViewBagList()
        {
            ViewBag.v0 = "Hakkımda İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yeni Hakkımda Girişi";
            ViewBag.v3 = "Hakkımda Listesi";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            AboutViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            AboutViewBagList();
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }
        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
