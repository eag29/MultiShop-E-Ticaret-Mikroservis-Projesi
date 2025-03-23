using _MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("orderings/orderings/GetOrderingByUserId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;

            /*var responseMessage = await _httpClient.GetAsync("orderings/GetOrderingByUserId?id=" + id);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"API isteği başarısız oldu: {responseMessage.StatusCode}");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine($"API JSON Cevabı: {jsonData}"); // API'den dönen veriyi görmek için

            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);

            if (values == null)
            {
                throw new Exception("Deserialize işlemi sonucunda null değer döndü.");
            }

            return values;*/
        }
    }
}
