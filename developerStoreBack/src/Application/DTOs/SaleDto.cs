using System;
using System.Collections.Generic;
using DeveloperStoreBack.Domain.Entities;

namespace DeveloperStoreBack.Application.DTOs
{
    public class SaleDto
    {
        public required string CustomerEmail { get; set; }
        public required string Branch { get; set; }
        public required List<SaleItemDto> Items { get; set; }

        public static SaleDto FromUser(Sale sale)
        {
            return new SaleDto
            {
                CustomerEmail = sale.CustomerEmail,
                Branch = sale.Branch,
                Items = sale.Items.ConvertAll(item => new SaleItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount
                })
            };
        }
    }
    
    public class SaleItemDto
    {
        public required string ProductId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required decimal Discount { get; set; }
    }
}