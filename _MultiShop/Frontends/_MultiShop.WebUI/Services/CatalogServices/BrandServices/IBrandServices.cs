using _MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandServices
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
    }
}
