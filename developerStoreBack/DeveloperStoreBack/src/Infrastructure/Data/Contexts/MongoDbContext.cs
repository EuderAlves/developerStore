using MongoDB.Driver;
using DeveloperStoreBack.Domain.Entities;

namespace DeveloperStoreBack.Infrastructure.Data.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Sale> Sales => _database.GetCollection<Sale>("Sales");
        public IMongoCollection<Item> Items => _database.GetCollection<Item>("Items");
    }
}