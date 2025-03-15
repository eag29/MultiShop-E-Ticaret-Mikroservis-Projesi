using _MultiShop.Catalog.Dtos.ProductDtos;
using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using AutoMapper;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using ZstdSharp.Unsafe;
using static MongoDB.Driver.WriteConcern;

namespace _MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IMongoCollection<Product> _product;
        private IMongoCollection<Category> _category;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var databaseName = client.GetDatabase(_databaseSettings.DatabaseName);
            _product = databaseName.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _category = databaseName.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _product.InsertOneAsync(values);
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _product.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
        public async Task DeleteProductAsync(string id)
        {
            await _product.DeleteOneAsync(x => x.ProductID == id);
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _product.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _product.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }
        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _product.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _category.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id)
        {
            var values = await _product.Find(x => x.CategoryID == id).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _category.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }
    }
}
