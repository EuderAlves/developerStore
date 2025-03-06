using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeveloperStoreBack.Domain.Entities
{
    public class Item
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public required string ProductId { get; set; }
        public required string Name { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int StockQuantity { get; set; }
    }
}