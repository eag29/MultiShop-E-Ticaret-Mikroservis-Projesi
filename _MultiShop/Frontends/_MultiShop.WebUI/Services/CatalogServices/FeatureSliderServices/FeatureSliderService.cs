using _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createFeatureSliderDto);
        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders?id=", updateFeatureSliderDto);
        }
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders?id=" + id);
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            return values;
        }
        public async Task<FeatureSliderGetByIdDto> FeatureSliderGetByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<FeatureSliderGetByIdDto>();
            return values;
        }
    }
}
