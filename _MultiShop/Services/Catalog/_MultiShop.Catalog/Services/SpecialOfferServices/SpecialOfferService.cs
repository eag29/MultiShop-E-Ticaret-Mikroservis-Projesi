using _MultiShop.Catalog.Dtos.FeatureSliderDto;
using _MultiShop.Catalog.Dtos.SpecialOfferDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(values);
        }
        public async Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferID == updateSpecialOfferDto.SpecialOfferID, values);
        }
        public async Task DeleteAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferID == id);
        }
        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }
        public async Task<GetByIdSpecialOfferDto> GetByIdAsync(string id)
        {
            var values = await _specialOfferCollection.Find(x => x.SpecialOfferID == id).FirstAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }
    }
}
