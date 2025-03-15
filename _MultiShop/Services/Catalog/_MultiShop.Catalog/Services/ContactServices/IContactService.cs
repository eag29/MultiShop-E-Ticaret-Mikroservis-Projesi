using _MultiShop.Catalog.Dtos.ContactDtos;

namespace _MultiShop.Catalog.Services.ContactServices
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
