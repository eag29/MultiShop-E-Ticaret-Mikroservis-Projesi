using _MultiShop.Catalog.Dtos.SpecialOfferDtos;
using _MultiShop.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _specialOfferService.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SpecialOfferGetById(string id)
        {
            var values = await _specialOfferService.GetByIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateAsync(createSpecialOfferDto);
            return Ok("Özel teklif ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateAsync(updateSpecialOfferDto);
            return Ok("Özel teklif güncelleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteAsync(id);
            return Ok("Özel teklif silme işlemi başarılı");
        }
    }
}
