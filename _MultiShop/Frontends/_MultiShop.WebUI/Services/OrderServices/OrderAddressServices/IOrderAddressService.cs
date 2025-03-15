using _MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace _MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        /*Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);*/
    }
}
