using _MultiShop.DtoLayer.CatalogDtos.FeaureSliderDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task<FeatureSliderGetByIdDto> FeatureSliderGetByIdAsync(string id);
        //Task<FeatureSliderGetByCategoryIdDto> FeatureSliderCategoryGetByIdAsync(string id);
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
    }
}
