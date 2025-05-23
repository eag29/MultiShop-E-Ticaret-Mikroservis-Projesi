﻿using _MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace _MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService: IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("http://localhost:5237/services/catalog/contacts", createContactDto);
        }
        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("http://localhost:5237/services/catalog/contacts?id=", updateContactDto);
        }
        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:5237/services/catalog/contacts?id=");
        }
        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return values;
        }
        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5237/services/catalog/contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }
    }
}
