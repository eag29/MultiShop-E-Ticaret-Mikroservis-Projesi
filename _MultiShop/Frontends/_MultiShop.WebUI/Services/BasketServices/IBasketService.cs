using _MultiShop.DtoLayer.BasketDtos;

namespace _MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task DeleteBasket(string UserId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task<BasketTotalDto> GetBasket();
        Task<bool> RemoveBasketItem(string productID);
    }
}
