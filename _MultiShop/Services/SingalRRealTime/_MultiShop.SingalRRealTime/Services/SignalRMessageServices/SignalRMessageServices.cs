
namespace _MultiShop.SingalRRealTime.Services.SignalMessageServices
{
    public class SignalRMessageServices : ISignalRMessageServices
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7282/api/UserMessages/GetTotalMessageCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
