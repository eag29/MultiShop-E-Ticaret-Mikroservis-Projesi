using _MultiShop.Catalog.Dtos.OfferDiscountDto;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.OfferDiscountService
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private IMongoCollection<OfferDiscount> _OfferDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //bağlantı yolu alınır.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veri tabanı adı alınır.
            _OfferDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _OfferDiscountCollection.InsertOneAsync(values);
        }
        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _OfferDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountID == updateOfferDiscountDto.OfferDiscountID, values);
        }
        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _OfferDiscountCollection.DeleteOneAsync(x => x.OfferDiscountID == id);
        }
        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _OfferDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _OfferDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(values);
        }
        public async Task<GetByProductIdOfferDiscountDto> GetByProductIdOfferDiscountAsync(string id)
        {
            var values  = await _OfferDiscountCollection.Find<OfferDiscount>(x=> x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductIdOfferDiscountDto>(values);
        }
    }
}
