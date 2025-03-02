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
    }
}