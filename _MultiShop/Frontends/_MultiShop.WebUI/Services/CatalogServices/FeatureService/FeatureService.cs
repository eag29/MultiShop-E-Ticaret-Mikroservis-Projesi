using _MultiShop.DtoLayer.CatalogDtos.FeaureDtos;
using _MultiShop.DtoLayer.CatalogDtos.FeaureDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.FeatureService
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
        }
        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features?id=", updateFeatureDto);
        }
        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features?id=" + id);
        }
        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var responseMessage = await _httpClient.GetAsync("features");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return values;
        }
        public async Task<FeatureGetByIdDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<FeatureGetByIdDto>();
            return values;
        }
    }
}
