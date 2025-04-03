using _MultiShop.Catalog.Entities;
using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("http://localhost:5237/services/catalog/products", createProductDto);
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("http://localhost:5237/services/catalog/products?id=", updateProductDto);
        }
        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/products?id=" + id);
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return values;
        }
        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }
        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/products/ProductListWithCategoryByCategoryId/" + CategoryId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }
    }
}
