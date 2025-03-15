using _MultiShop.Catalog.Dtos.FeatureDtos;
using _MultiShop.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureGetById(string id)
        {
            var values = await _featureService.FeatureGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            _featureService.DeleteFeatureAsync(id);
            return Ok("Sileme işlemi başarılı");
        }
    }
}
