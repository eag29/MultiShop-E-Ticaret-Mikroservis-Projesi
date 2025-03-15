using _MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace _MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdAsync(string id);
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
    }
}
