using _MultiShop.Catalog.Dtos.ProductImageDtos;

namespace _MultiShop.Catalog.Services.ProductImageImageServices
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
