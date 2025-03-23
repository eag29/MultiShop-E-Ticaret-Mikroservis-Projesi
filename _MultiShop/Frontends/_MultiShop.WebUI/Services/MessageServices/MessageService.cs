using _MultiShop.DtoLayer.MessageDtos;

namespace _MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7282/api/UserMessages/GetMessageInbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }
        public async Task<List<ResultISendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7282/api/UserMessages/GetMessageSendbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultISendboxMessageDto>>();
            return values;
        }
        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7282/api/UserMessages/GetTotalMessageCountByReceiverId?id" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
