using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DeveloperStoreBack.Domain.Entities
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        public string Email { get; set; }

        [BsonRequired]
        public string PasswordHash { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string CompanyName { get; set; }


        public User()
        {
            Email = string.Empty;
            PasswordHash = string.Empty;
            Name = string.Empty;
            CompanyName = string.Empty;
        }
    }
}