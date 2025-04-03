using _MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("http://localhost:5237/services/catalog/abouts", createAboutDto);
        }
        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("http://localhost:5237/services/catalog/abouts?id=", updateAboutDto);
        }
        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/abouts?id=" + id);
        }
        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/abouts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdAboutDto>();
            return values;
        }
    }
}
