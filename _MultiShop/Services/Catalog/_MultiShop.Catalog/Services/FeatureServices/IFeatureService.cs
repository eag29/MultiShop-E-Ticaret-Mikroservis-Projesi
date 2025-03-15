using _MultiShop.Catalog.Dtos.FeatureDtos;

namespace _MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<FeatureGetByIdDto> FeatureGetByIdAsync(string id);
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
    }
}
