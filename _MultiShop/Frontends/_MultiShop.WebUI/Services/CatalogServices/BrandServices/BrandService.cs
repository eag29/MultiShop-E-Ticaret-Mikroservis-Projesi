using _MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandServices
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("http://localhost:5237/services/catalog/brands", createBrandDto);
        }
        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("http://localhost:5237/services/catalog/brands?id=", updateBrandDto);
        }
        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/brands?id=" + id);
        }
        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdBrandDto>();
            return values;
        }
    }
}
