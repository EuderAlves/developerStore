using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Infrastructure.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MongoDbContext _context;

        public ItemRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Item item)
        {
            await _context.Items.InsertOneAsync(item);
        }

        public async Task<Item> GetItemByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            return await _context.Items.Find(i => i.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            await _context.Items.ReplaceOneAsync(i => i.Id == item.Id, item);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            await _context.Items.DeleteOneAsync(i => i.Id == objectId);
        }
    }
}