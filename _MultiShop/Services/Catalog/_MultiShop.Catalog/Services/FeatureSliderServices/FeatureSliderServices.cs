using _MultiShop.Catalog.Dtos.FeatureSliderDto;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderServices : IFeatureSliderService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<FeatureSlider> _FeatureSliderCollection;

        public FeatureSliderServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _FeatureSliderCollection.InsertOneAsync(values);
        }
        public async Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, values);
        }
        public async Task DeleteAsync(string id)
        {
            await _FeatureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            var values = await _FeatureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }
        public async Task<FeatureSliderGetByIdDto> GetByIdAsync(string id)
        {
            var values = await _FeatureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<FeatureSliderGetByIdDto>(values);
        }
        public async Task<FeatureSliderGetByCategoryIdDto> GetByCategoryIdAsync(string id)
        {
            var values = await _FeatureSliderCollection.Find(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<FeatureSliderGetByCategoryIdDto>(values);
        }
        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }
        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
