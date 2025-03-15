using _MultiShop.Basket.Dtos;
using _MultiShop.Basket.Settings;
using System.Text.Json;

namespace _MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<BasketTotalDto> GetBasket(string UserId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
        public async Task DeleteBasket(string UserId)
        {
             await _redisService.GetDb().KeyDeleteAsync(UserId);
        }
    }
}
