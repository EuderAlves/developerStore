using DeveloperStoreBack.Domain.Entities;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Domain.Repositories
{
    public interface IItemRepository
    {
        Task InsertAsync(Item item);
        Task<Item> GetItemByIdAsync(string id);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task UpdateAsync(Item item);
        Task DeleteAsync(string id);
    }
}