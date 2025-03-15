using _MultiShop.Catalog.Dtos.AboutDtos;

namespace _MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
    }
}
