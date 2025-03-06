using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDbContext _context;

        public UserRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            return await _context.Users.Find(u => u.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserDataByEmailAsync(string email)
        {
            return await _context.Users.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await _context.Users.ReplaceOneAsync(u => u.Email == user.Email, user);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            await _context.Users.DeleteOneAsync(u => u.Id == objectId);
        }
    }
}