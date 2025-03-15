using _MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIDImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
    }
}
