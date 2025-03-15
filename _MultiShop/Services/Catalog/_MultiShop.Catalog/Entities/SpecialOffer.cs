using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _MultiShop.Catalog.Entities
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
