using _MultiShop.Catalog.Dtos.OfferDiscountDto;

namespace _MultiShop.Catalog.Services.OfferDiscountService
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
        Task<GetByProductIdOfferDiscountDto> GetByProductIdOfferDiscountAsync(string id);
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
    }
}
