using _MultiShop.Catalog.Dtos.ProductDtos;
using _MultiShop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductyService;

        public ProductsController(IProductService ProductyService)
        {
            _ProductyService = ProductyService;
        }
        
        [HttpGet]
        public async Task<IActionResult> ProductyList()
        {
            var values = await _ProductyService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductyById(string id)
        {
            var values = await _ProductyService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _ProductyService.GetProductsWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategoryByCategoryId/{id}")]
        public async Task<IActionResult> ProductListWithCategory(string id)
        {
            var values = await _ProductyService.GetProductsWithCategoryByCategoryIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _ProductyService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductyService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductyService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }
    }
}
