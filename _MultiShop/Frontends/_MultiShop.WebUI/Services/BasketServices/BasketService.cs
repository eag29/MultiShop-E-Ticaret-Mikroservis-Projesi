using _MultiShop.DtoLayer.BasketDtos;

namespace _MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/basket/baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null) //Sepet değeri var ise
            {
                if (!values.BasketItems.Any(x => x.ProductID == basketItemDto.ProductID))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);

        }
        public async Task DeleteBasket(string UserId)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/basket/baskets?id=" + UserId);
        }
        public async Task<bool> RemoveBasketItem(string productID)
        {
            var values = await GetBasket(); // Mevcut kullanıcının sepeti getirilir.
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productID); // Silinecek öğeyi hafızaya alır.
            var result = values.BasketItems.Remove(deletedItem); // Hafızaya alınan ürün sepetten kaldırılrır.
            await SaveBasket(values); // Sepetteki değişiklikler kaydedilir.
            return true;
        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            //http://localhost:5237/services/basket/baskets
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("http://localhost:5237/services/basket/baskets", basketTotalDto);
        }
    }
}
