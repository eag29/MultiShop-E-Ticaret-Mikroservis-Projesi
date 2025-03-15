using _MultiShop.Catalog.Dtos.FeatureDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<Feature> _featureCollection;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(values);
        }
        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, values);
        }
        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }
        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }
        public async Task<FeatureGetByIdDto> FeatureGetByIdAsync(string id)
        {
            var values = await _featureCollection.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<FeatureGetByIdDto>(values);
        }
    }
}
