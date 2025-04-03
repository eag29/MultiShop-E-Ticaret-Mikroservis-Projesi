
namespace _MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<long> GetFeatureSliderCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetFeatureSliderCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
        public async Task<long> GetProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetMaxPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }
        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetMinPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }
        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7093/api/Statistics/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }
    }
}
