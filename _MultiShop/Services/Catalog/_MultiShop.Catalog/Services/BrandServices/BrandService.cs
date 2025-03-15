using _MultiShop.Catalog.Dtos.BrandDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
       private readonly IMapper _mapper;
       private readonly IMongoCollection<Brand> _brandCollection;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //bağlantı yolu alınır.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veri tabanı adı alınır.
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var values = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(values);
        }
        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, values);
        }
        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }
        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }
        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _brandCollection.Find<Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(values);
        }
    }
}
