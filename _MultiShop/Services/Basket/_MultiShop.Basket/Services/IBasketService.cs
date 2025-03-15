using _MultiShop.Basket.Dtos;

namespace _MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string UserId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string UserId);
    }
}
