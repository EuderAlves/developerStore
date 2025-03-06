using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Application.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DeveloperStoreBack.Application.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly SaleNotificationService _notificationService;

        public SaleService(ISaleRepository saleRepository, SaleNotificationService notificationService)
        {
            _saleRepository = saleRepository;
            _notificationService = notificationService;
        }

        public async Task<SaleReturnDto> RegisterSale(SaleDto saleDto)
        {
            var nextSaleNumber = await _saleRepository.GetNextSaleNumberAsync();

            var sale = new Sale
            {
                SaleNumber = nextSaleNumber,
                SaleDate = DateTime.UtcNow,
                CustomerEmail = saleDto.CustomerEmail,
                Branch = saleDto.Branch,
                IsCanceled = false,
                IsFinalized = false,
                Items = MapSaleItems(saleDto.Items)
            };

            sale.TotalValue = CalculateTotalValue(sale.Items, out decimal totalDiscount);
            sale.TotalDiscount = totalDiscount;

            await _saleRepository.InsertAsync(sale);

            // Retorna um DTO com o Id como string
            return new SaleReturnDto
            {
                Id = sale.Id.ToString(), // Converte o ObjectId para string
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                CustomerEmail = sale.CustomerEmail,
                TotalValue = sale.TotalValue,
                TotalDiscount = sale.TotalDiscount,
                Branch = sale.Branch,
                Items = sale.Items.Select(item => new SaleItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount
                }).ToList(),
                IsCanceled = sale.IsCanceled,
                IsFinalized = sale.IsFinalized
            };
        }

        public async Task<IEnumerable<SaleReturnDto>> GetSalesByCustomerEmail(string email)
        {
            var sales = await _saleRepository.GetSalesByCustomerEmailAsync(email);
            var salesReturnDto = sales.Select(sale => new SaleReturnDto
            {
                Id = sale.Id.ToString(),
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                CustomerEmail = sale.CustomerEmail,
                TotalValue = sale.TotalValue,
                TotalDiscount = sale.TotalDiscount,
                Branch = sale.Branch,
                Items = sale.Items.Select(item => new SaleItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount,
                    DiscountPercentage = item.DiscountPercentage
                }).ToList(),
                IsCanceled = sale.IsCanceled,
                IsFinalized = sale.IsFinalized
            });
            return salesReturnDto;
        }

        public async Task CancelSale(string id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);
            if (sale == null || sale.IsFinalized)
            {
                throw new ArgumentException("Venda não encontrada ou já finalizada.");
            }

            sale.IsCanceled = true;
            await _saleRepository.UpdateAsync(sale);

            _notificationService.Notify(new SaleNotificationDto
            {
                Message = "Venda cancelada.",
                SaleId = sale.Id.ToString()
            });
        }

        public async Task CancelSaleItem(string saleId, string productId)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(saleId);
            if (sale == null || sale.IsFinalized)
            {
                throw new ArgumentException("Venda não encontrada ou já finalizada.");
            }

            var item = sale.Items.Find(i => i.ProductId == productId);
            if (item != null)
            {
                item.IsCanceled = true;
                await _saleRepository.UpdateAsync(sale);

                _notificationService.Notify(new SaleNotificationDto
                {
                    Message = $"Item cancelado: {productId}.",
                    SaleId = sale.Id.ToString()
                });
            }
        }

        public async Task UpdateSaleItem(string saleId, SaleItemDto updatedItemDto)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(saleId);
            if (sale == null || sale.IsFinalized)
            {
                throw new ArgumentException("Venda não encontrada ou já finalizada.");
            }

            var item = sale.Items.Find(i => i.ProductId == updatedItemDto.ProductId);
            if (item != null)
            {
                item.Quantity = updatedItemDto.Quantity;
                item.UnitPrice = updatedItemDto.UnitPrice;
                item.Discount = updatedItemDto.Discount;
                await _saleRepository.UpdateAsync(sale);

                _notificationService.Notify(new SaleNotificationDto
                {
                    Message = "Item da venda atualizado.",
                    SaleId = sale.Id.ToString()
                });
            }
        }

        public async Task FinalizeSale(string saleId)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(saleId);
            if (sale == null)
            {
                throw new ArgumentException("Venda não encontrada.");
            }

            sale.IsFinalized = true;
            await _saleRepository.UpdateAsync(sale);

            _notificationService.Notify(new SaleNotificationDto
            {
                Message = "Venda finalizada com sucesso!",
                SaleId = sale.Id.ToString()
            });
        }

        public async Task DeleteSale(string id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);
            if (sale == null || sale.IsFinalized)
            {
                throw new ArgumentException("Venda não encontrada ou já finalizada.");
            }

            await _saleRepository.DeleteAsync(id);

            _notificationService.Notify(new SaleNotificationDto
            {
                Message = "Venda deletada!",
                SaleId = sale.Id.ToString()
            });
        }

        private decimal CalculateTotalValue(List<SaleItem> items, out decimal totalDiscount)
        {
            decimal total = 0;
            totalDiscount = 0;
            foreach (var item in items)
            {
                decimal discount = 0;
                if (item.Quantity >= 4 && item.Quantity <= 20)
                {
                    if (item.Quantity >= 10)
                    {
                        discount = item.UnitPrice * item.Quantity * 0.20m;
                        item.DiscountPercentage = 20.0m;
                    }
                    else
                    {
                        discount = item.UnitPrice * item.Quantity * 0.10m;
                        item.DiscountPercentage = 10.0m;
                    }
                }
                else
                {
                    item.Discount = 0;
                    item.DiscountPercentage = 0;
                }

                if (item.Quantity > 20)
                {
                    throw new ArgumentException("Não é possível vender mais de 20 itens idênticos.");
                }

                total += (item.UnitPrice * item.Quantity) - discount;
                totalDiscount += discount; 
            }
            return total;
        }

        public decimal CalculateDiscountPercentage(List<SaleItem> items)
        {
            decimal totalDiscount = 0;
            decimal totalPrice = 0;

            foreach (var item in items)
            {
                totalPrice += item.Quantity * item.UnitPrice;
                totalDiscount += item.Discount;
            }


            return totalPrice > 0 ? (totalDiscount / totalPrice) * 100 : 0;
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