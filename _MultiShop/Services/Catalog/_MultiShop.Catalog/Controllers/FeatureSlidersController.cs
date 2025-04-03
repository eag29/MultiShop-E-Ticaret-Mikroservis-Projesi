using _MultiShop.Catalog.Dtos.FeatureSliderDto;
using _MultiShop.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureSliderGetById(string id)
        {
            var values = await _featureSliderService.GetByIdAsync(id);
            return Ok(values);
        }
        [HttpGet("{FeatureSliderGetByCategoryIdAsync}")]
        public async Task<IActionResult> FeatureSliderGetByCategoryIdAsync(string id)
        {
            var values = await _featureSliderService.GetByIdAsync(id);
            return Ok(values);
        }    
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel güncelleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return Ok("Öne çıkan görsel silme işlemi başarılı");
        }
    }
}
