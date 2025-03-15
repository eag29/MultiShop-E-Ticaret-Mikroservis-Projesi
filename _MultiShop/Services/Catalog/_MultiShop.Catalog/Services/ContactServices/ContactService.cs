using _MultiShop.Catalog.Dtos.CategoryDtos;
using _MultiShop.Catalog.Dtos.ContactDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Contact> _contact;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //bağlantı yolu alınır.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veri tabanı adı alınır.
            _contact = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            await _contact.InsertOneAsync(values);
        }
        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contact.FindOneAndReplaceAsync(x => x.ContactID == updateContactDto.ContactID, values);
        }
        public async Task DeleteContactAsync(string id)
        {
            await _contact.DeleteOneAsync(x => x.ContactID == id);
        }
        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contact.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }
        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contact.Find<Contact>(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }
    }
}
