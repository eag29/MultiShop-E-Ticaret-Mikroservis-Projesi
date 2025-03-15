using _MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace _MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
    }
}
