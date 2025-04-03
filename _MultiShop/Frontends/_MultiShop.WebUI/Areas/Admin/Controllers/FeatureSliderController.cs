using _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;
        private readonly ICategoryService _categoryService;

        public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _featureSliderService = featureSliderService;
            _categoryService = categoryService;
        }

        void FeatureSliderViewBagList()
        {
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewBagList();
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            FeatureSliderViewBagList();
            var CategoryValues = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in CategoryValues
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewBagList();
            var CategoryValues = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in CategoryValues
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var values = await _featureSliderService.FeatureSliderGetByIdAsync(id);
            return View(values);
        }
        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
