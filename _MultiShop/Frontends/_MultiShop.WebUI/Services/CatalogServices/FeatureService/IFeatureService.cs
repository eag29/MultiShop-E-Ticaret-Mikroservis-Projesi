using _MultiShop.DtoLayer.CatalogDtos.FeaureDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.FeatureService
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<FeatureGetByIdDto> GetByIdFeatureAsync(string id);
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
    }
}
