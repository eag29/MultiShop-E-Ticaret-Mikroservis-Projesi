using _MultiShop.Catalog.Dtos.ProductDetailDtos;
using _MultiShop.Catalog.Dtos.ProductDtos;

namespace _MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIDProductDetailAsync(string id);
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    }
}
