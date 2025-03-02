using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Application.Services
{
    public class UserService
    {
        private readonly MongoDbContext _context;

        public UserService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Usuário inválido.");
            }

            user.PasswordHash = HashPassword(user.PasswordHash);
            await _context.Users.InsertOneAsync(user);

            return user;
        }

        public async Task<bool> Login(UserLoginDto userDto)
        {
            var existingUser = await _context.Users
                .Find(u => u.Email == userDto.Email)
                .FirstOrDefaultAsync();

            if (existingUser == null || !VerifyPassword(userDto.PasswordHash, existingUser.PasswordHash))
            {
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}