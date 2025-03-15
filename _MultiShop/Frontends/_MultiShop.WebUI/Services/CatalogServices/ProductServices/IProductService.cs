using _MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.ProductServices
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
