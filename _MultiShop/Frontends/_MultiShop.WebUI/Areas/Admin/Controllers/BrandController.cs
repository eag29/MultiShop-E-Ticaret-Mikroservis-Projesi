using _MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using _MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandServices _brandServices;

        public BrandController(IHttpClientFactory httpClientFactory, IBrandServices brandServices)
        {
            _httpClientFactory = httpClientFactory;
            _brandServices = brandServices;
        }

        void BrandViewBagList()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yeni Marka Girişi";
            ViewBag.v3 = "Marka Listesi";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandViewBagList();
            var values = await _brandServices.GetAllBrandAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            BrandViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandServices.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandServices.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewBagList();
            var values = await _brandServices.GetByIdBrandAsync(id);
            return View(values);
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandServices.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
