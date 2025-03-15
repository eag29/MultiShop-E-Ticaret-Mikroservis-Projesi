using _MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
