using _MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace _MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("http://localhost:5237/services/address", createOrderAddressDto);
        }
    }
}
