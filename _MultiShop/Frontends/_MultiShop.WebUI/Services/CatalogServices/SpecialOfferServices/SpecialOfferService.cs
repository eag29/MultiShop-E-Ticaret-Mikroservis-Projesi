using _MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("http://localhost:5237/services/catalog/specialoffers", createSpecialOfferDto);
        }
        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("http://localhost:5237/services/catalog/specialoffers?id=", updateSpecialOfferDto);
        }
        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/specialoffers?id=" + id);
        }
        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/specialoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();
            return values;
        }
    }
}
