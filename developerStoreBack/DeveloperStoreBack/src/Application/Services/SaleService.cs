using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Domain.Repositories;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Application.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> RegisterSale(SaleDto saleDto)
        {
            var sale = new Sale
            {
                SaleDate = DateTime.UtcNow,
                CustomerEmail = saleDto.CustomerEmail,
                Branch = saleDto.Branch,
                IsCanceled = false,
                TotalValue = CalculateTotalValue(saleDto.Items),
                Items = MapSaleItems(saleDto.Items)
            };

            await _saleRepository.InsertAsync(sale);
            return sale;
        }

        public async Task<IEnumerable<Sale>> GetSalesByCustomerEmail(string email)
        {
            return await _saleRepository.GetSalesByCustomerEmailAsync(email);
        }

        private decimal CalculateTotalValue(List<SaleItemDto> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += (item.UnitPrice * item.Quantity) - item.Discount;
            }
            return total;
        }

        private List<SaleItem> MapSaleItems(List<SaleItemDto> itemDtos)
        {
            var saleItems = new List<SaleItem>();
            foreach (var itemDto in itemDtos)
            {
                saleItems.Add(new SaleItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = itemDto.UnitPrice,
                    Discount = itemDto.Discount
                });
            }
            return saleItems;
        }
    }
}