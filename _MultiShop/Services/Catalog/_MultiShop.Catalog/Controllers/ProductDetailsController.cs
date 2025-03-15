using _MultiShop.Catalog.Dtos.ProductDetailDtos;
using _MultiShop.Catalog.Dtos.ProductDtos;
using _MultiShop.Catalog.Services.ProductDetailServices;
using _MultiShop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
       private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDProductDetail(string id)
        {
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpGet("GetProductDetailByProductID/{id}")]
        public async Task<IActionResult> GetProductDetailByProductID(string id)
        {
            var values = await _productDetailService.GetByProductIDProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
