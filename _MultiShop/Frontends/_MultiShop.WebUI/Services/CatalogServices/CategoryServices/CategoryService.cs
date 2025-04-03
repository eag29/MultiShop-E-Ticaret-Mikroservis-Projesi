using _MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("http://localhost:5237/services/catalog/categories", createCategoryDto);
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("http://localhost:5237/services/catalog/categories?id=", updateCategoryDto);
        }
        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/categories?id=" + id);
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return values;
        }
    }
}
