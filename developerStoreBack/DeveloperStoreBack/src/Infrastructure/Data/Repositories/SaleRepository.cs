using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Infrastructure.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MongoDbContext _context;

        public SaleRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Sale sale)
        {
            await _context.Sales.InsertOneAsync(sale);
        }

        public async Task<Sale> GetSaleByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            return await _context.Sales.Find(s => s.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesByCustomerEmailAsync(string email)
        {
            return await _context.Sales.Find(s => s.CustomerEmail == email).ToListAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            await _context.Sales.ReplaceOneAsync(s => s.Id == sale.Id, sale);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            await _context.Sales.DeleteOneAsync(s => s.Id == objectId);
        }

        public async Task<int> GetNextSaleNumberAsync()
        {
            var lastSale = await _context.Sales.Find(_ => true)
                .SortByDescending(s => s.SaleNumber)
                .FirstOrDefaultAsync();

            return lastSale == null ? 1 : lastSale.SaleNumber + 1;
        }
    }
}