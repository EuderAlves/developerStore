using System;
using System.Collections.Generic;

namespace DeveloperStoreBack.Application.DTOs
{
    public class SaleReturnDto
    {
        public string Id { get; set; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalDiscount { get; set; }
        public string Branch { get; set; }
        public List<SaleItemDto> Items { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFinalized { get; set; }
    }

   
}