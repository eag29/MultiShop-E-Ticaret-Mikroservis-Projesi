using _MultiShop.Catalog.Dtos.FeatureSliderDto;

namespace _MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllAsync();
        Task<FeatureSliderGetByIdDto> GetByIdAsync(string id);
        Task<FeatureSliderGetByCategoryIdDto> GetByCategoryIdAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
        Task CreateAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteAsync(string id);
    }
}
