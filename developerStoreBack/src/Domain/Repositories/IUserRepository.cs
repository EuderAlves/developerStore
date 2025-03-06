using DeveloperStoreBack.Domain.Entities;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Domain.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserDataByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
    }
}