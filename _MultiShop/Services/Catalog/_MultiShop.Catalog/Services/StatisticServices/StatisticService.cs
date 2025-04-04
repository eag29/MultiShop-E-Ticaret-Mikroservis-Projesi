﻿using _MultiShop.Catalog.Entities;
using _MultiShop.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Brand> _brands;
        private readonly IMongoCollection<FeatureSlider> _featuresliders;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categories = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _products = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _brands = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _featuresliders = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        }


        public async Task<long> GetFeatureSliderCount()
        {
            return await _featuresliders.CountDocumentsAsync(FilterDefinition<FeatureSlider>.Empty);
        }
        public async Task<long> GetCategoryCount()
        {
            return await _categories.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }
        public async Task<long> GetProductCount()
        {
            return await _products.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
        public async Task<long> GetBrandCount()
        {
            return await _brands.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }
        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                {
                    {"_id", null },
                    {"averagePrice",new BsonDocument("$avg","ProductPrice") }
                })
            };
            var result = await _products.AggregateAsync<BsonDocument>(pipeline);
            var value = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return value;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _products.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _products.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
    }
}
