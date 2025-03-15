using _MultiShop.DtoLayer.CatalogDtos.OfferDiscountDto;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.OfferDiscountService
{
    public class OfferDiscountService: IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createOfferDiscountDto);
        }
        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts?id=", updateOfferDiscountDto);
        }
        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
        }
        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdOfferDiscountDto>();
            return values;
        }
    }
}
