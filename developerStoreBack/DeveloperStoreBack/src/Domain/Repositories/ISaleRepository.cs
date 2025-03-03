using DeveloperStoreBack.Domain.Entities;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task InsertAsync(Sale sale);
        Task<Sale> GetSaleByIdAsync(string id);
        Task<IEnumerable<Sale>> GetSalesByCustomerEmailAsync(string email);
    }
}