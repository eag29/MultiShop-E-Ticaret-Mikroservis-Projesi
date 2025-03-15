using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductImageDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v0 = "Ürün Görselleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Görselleri";
            ViewBag.v3 = "Ürün Görselleri Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7093/api/ProductImages/ProductImagesByProductID?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7093/api/ProductImages", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
