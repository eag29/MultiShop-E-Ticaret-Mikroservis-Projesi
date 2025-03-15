using _MultiShop.DtoLayer.DiscountDtos;

namespace _MultiShop.WebUI.Services.DiscountServcies
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7094/api/Discounts/GetCodeDetailByCode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7094/api/Discounts/GetDiscountCouponRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
