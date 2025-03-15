using _MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        void ProductViewBagList()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            /*var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7093/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }*/
            return View();
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            Console.WriteLine($"Product Name: {createProductDto.ProductName}");
            Console.WriteLine($"Product Price: {createProductDto.ProductPrice}");
            Console.WriteLine($"Product Description: {createProductDto.ProductDescription}");
            Console.WriteLine($"Product Image URL: {createProductDto.ProductImageUrl}");
            Console.WriteLine($"CategoryID: {createProductDto.CategoryID}");

            Console.WriteLine("CreateProductAsync metodu çağrıldı.");
            Console.WriteLine($"CategoryID Backend'e ulaştı: {createProductDto.CategoryID}");

            Console.WriteLine("Ürün başarıyla eklendi!");

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProducts(string id)
        {
            ProductViewBagList();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
