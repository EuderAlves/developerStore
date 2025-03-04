using System;
using System.Collections.Generic;

namespace DeveloperStoreBack.Application.DTOs
{
    public class SaleDto
    {
        public required string CustomerEmail { get; set; }
        public required string Branch { get; set; }
        public required List<SaleItemDto> Items { get; set; }
    }

    public class SaleItemDto
    {
        public required string ProductId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required decimal Discount { get; set; }
    }
}