using _MultiShop.Discount.Dtos;
using _MultiShop.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _discountService.GetAllCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CouponGetById(int id)
        {
            var values = await _discountService.GetByIdCouponAsync(id);
            return Ok(values);
        }
        [HttpGet("GetCodeDetailByCode")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
            var values = await _discountService.GetCodeDetailByCode(code);
            return Ok(values);
        }
        [HttpGet("GetDiscountCouponRate")]
        public IActionResult GetDiscountCouponRate(string code)
        {
            var values = _discountService.GetDiscountCouponRateAsync(code);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi");
        }
    }
}
