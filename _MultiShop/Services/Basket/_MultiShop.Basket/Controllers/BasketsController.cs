using _MultiShop.Basket.Dtos;
using _MultiShop.Basket.LoginServices;
using _MultiShop.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims; //Sisteme girmiş olan tokena ait girilmiş bilgileri verir.
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}
