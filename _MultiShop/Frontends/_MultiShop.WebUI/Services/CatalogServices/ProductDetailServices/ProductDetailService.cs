﻿using _MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using AutoMapper;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("http://localhost:5237/services/catalog/productdetails", createProductDetailDto);
        }
        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("http://localhost:5237/services/catalog/productdetails", updateProductDetailDto);
        }
        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync(id);
        }
        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/productdetails");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }
        public async Task<GetByIdProductDetailDto> GetByProductIDProductDetailAsync(string productDetailid)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/productdetails/GetProductDetailByProductID/" + productDetailid);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }
    }
}
