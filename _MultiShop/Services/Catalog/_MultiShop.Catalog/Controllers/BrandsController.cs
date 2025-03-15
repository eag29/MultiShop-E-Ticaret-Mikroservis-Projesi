using _MultiShop.Catalog.Dtos.BrandDtos;
using _MultiShop.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _BrandService.GetAllBrandAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _BrandService.GetByIdBrandAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return Ok("Marka başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _BrandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Marka başarıyla güncellendi");
        }
    }
}
