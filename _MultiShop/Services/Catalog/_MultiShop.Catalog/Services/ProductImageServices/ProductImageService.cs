using _MultiShop.Catalog.Dtos.ProductDtos;
using _MultiShop.Catalog.Dtos.ProductImageDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Services.ProductImageImageServices;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private IMongoCollection<ProductImage> _product;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var databaseName = client.GetDatabase(_databaseSettings.DatabaseName);
            _product = databaseName.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _product.InsertOneAsync(values);
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _product.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _product.DeleteOneAsync(x => x.ProductImageID == id);
        }
        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await _product.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _product.Find(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetByProductIDImageAsync(string id)
        {
            var values = await _product.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }
    }
}
