using _MultiShop.Catalog.Dtos.AboutDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.AboutServices
{
    public class AboutService: IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<About> _AboutCollection;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //bağlantı yolu alınır.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veri tabanı adı alınır.
            _AboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            await _AboutCollection.InsertOneAsync(values);
        }
        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _AboutCollection.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDto.AboutID, values);
        }
        public async Task DeleteAboutAsync(string id)
        {
            await _AboutCollection.DeleteOneAsync(x => x.AboutID == id);
        }
        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _AboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }
        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var values = await _AboutCollection.Find<About>(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }
    }
}
