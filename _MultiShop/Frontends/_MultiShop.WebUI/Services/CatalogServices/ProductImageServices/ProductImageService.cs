using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync(id);
        }
        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
            return values;
        }
        public async Task<GetByIdProductImageDto> GetByProductIDImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/ProductImagesByProductID/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
            return values;
        }
    }
}
