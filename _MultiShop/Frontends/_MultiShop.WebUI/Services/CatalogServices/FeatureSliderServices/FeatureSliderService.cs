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
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("http://localhost:5237/services/catalog/featuresliders", createFeatureSliderDto);
        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("http://localhost:5237/services/catalog/featuresliders?id=", updateFeatureSliderDto);
        }
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/featuresliders?id=" + id);
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/featuresliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            return values;
        }
        public async Task<FeatureSliderGetByIdDto> FeatureSliderGetByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<FeatureSliderGetByIdDto>();
            return values;
        }
        //public async Task<FeatureSliderGetByCategoryIdDto> FeatureSliderCategoryGetByIdAsync(string id)
        //{
        //    var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/featuresliders/" + id);
        //    var values = await responseMessage.Content.ReadFromJsonAsync<FeatureSliderGetByCategoryIdDto>();
        //    return values;
        //}
    }
}
