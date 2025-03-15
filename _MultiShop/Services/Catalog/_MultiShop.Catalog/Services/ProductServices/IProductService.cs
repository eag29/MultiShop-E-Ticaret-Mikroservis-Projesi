using _MultiShop.Catalog.Dtos.ProductDtos;

namespace _MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id);
    }
}
