using _MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace _MultiShop.WebUI.Services.CargoServices.CargoCustomerService
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomeByIdDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerById?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomeByIdDto>();
            return values;
        }
    }
}
