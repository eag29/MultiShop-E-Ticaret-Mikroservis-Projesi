using _MultiShop.Catalog.Dtos.ProductDetailDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private IMongoCollection<ProductDetail> _productDetail;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var databaseName = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetail = databaseName.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetail.InsertOneAsync(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetail.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);
        }
        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetail.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetail.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productDetail.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIDProductDetailAsync(string id)
        {
            var values = await _productDetail.Find<ProductDetail>(x => x.ProductID== id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }
    }
}
