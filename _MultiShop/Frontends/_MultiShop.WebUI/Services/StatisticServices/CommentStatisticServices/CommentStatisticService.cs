
namespace _MultiShop.WebUI.Services.StatisticServices.CommentServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<int> GetTotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7098/api/Comments/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7098/api/Comments/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
        public async Task<int> GetPassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7098/api/Comments/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
