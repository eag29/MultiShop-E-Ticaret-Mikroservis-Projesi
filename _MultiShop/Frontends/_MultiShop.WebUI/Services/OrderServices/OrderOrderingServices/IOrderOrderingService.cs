using _MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace _MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
