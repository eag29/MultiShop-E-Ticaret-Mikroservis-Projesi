using _MultiShop.Catalog.Dtos.ProductDetailDtos;
using _MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using _MultiShop.WebUI.Services.CatalogServices;
using _MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using _MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService, IHttpClientFactory httpClientFactory, IProductImageService productImageService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _httpClientFactory = httpClientFactory;
            _productImageService = productImageService;
            _productDetailService = productDetailService;
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
        public async Task<IActionResult> UpdateProduct(string id)
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
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        //[Route("ProductImageDetail/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> ProductImageDetail(string id)
        //{
        //    ProductViewBagList();
        //    var values = await _productImageService.GetByProductIDImageAsync(id);
        //    return View(values);
        //}
        //[Route("ProductImageDetail/{id}")]
        //[HttpPost]
        //public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        //{
        //    await _productImageService.UpdateProductImageAsync(updateProductImageDto);
        //    return RedirectToAction("Index", "Product", new { area = "Admin" });
        //}
        ////Images/ProductImages/TrasMakinesi/makine1.png
        //[Route("ProductDetail/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> ProductDetail(string id)
        //{
        //    ProductViewBagList();
        //    var values = await _productDetailService.GetByProductIDProductDetailAsync(id);
        //    return View(values);
        //}
        //[Route("ProductDetail/{id}")]
        //[HttpPost]
        //public async Task<IActionResult> ProductDetail(UpdateProductDetailDto updateProductDetailDto)
        //{
        //    await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        //    return RedirectToAction("Index", "Product", new { area = "Admin" });
        //}
    }
}
