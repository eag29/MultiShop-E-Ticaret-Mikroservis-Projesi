using _MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace _MultiShop.WebUI.Services.CatalogServices
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
