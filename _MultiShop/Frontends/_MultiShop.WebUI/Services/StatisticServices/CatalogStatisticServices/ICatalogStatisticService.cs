namespace _MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetFeatureSliderCount();
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
