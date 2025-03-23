using _MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CargoServices.CargoCompanyService
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanytDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("CargoCompany", createCargoCompanytDto);
        }
        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("CargoCompany", updateCargoCompanyDto);
        }
        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("CargoCompany?id=" + id);
        }
        public async Task<List<ResultCargoComnpanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompany");
            var jsonDta = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCargoComnpanyDto>>(jsonDta);
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompany/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }
    }
}
