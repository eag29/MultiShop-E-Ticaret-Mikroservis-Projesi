using _MultiShop.Catalog.Dtos.BrandDtos;

namespace _MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
    }
}
