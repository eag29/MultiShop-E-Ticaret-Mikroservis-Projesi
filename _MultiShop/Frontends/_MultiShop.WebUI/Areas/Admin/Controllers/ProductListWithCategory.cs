using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductListWithCategory")]
    public class ProductListWithCategory : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductListWithCategory(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
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
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }
        //[HttpGet]
        //[Route("CreateProductListWithCategory")]
        //public async Task<IActionResult> CreateProductListWithCategory()
        //{
        //    ProductViewBagList();

        //    var values = await _categoryService.GetAllCategoryAsync();
        //    List<SelectListItem> categoryValues = (from x in values
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = x.CategoryName,
        //                                               Value = x.CategoryID
        //                                           }).ToList();
        //    ViewBag.CategoryValues = categoryValues;
        //    return View();
        //}
        [HttpGet]
        [Route("CreateProductListWithCategory")]
        public IActionResult CreateProductListWithCategory()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateProductListWithCategory")]
        public async Task<IActionResult> CreateProductListWithCategory(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "ProductListWithCategory", new { area = "Admin" });
        }
        [Route("DeleteProductListWithCategory/{id}")]
        public async Task<IActionResult> DeleteProductListWithCategory(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "ProductListWithCategory", new { area = "Admin" });

        }
        [Route("UpdateProductListWithCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductListWithCategory(string id)
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
            return View(productValues);
        }

        [Route("UpdateProductListWithCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductListWithCategory(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "ProductListWithCategory", new { area = "Admin" });
        }
    }
}
