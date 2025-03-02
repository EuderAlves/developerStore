using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DeveloperStoreBack.Domain.Entities
{
    public class Sale
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public required DateTime SaleDate { get; set; }
        public required string CustomerEmail { get; set; }
        public decimal TotalValue { get; set; }
        public required string Branch { get; set; }
        public required List<SaleItem> Items { get; set; }
        public bool IsCanceled { get; set; }

        public Sale()
        {
            Items = new List<SaleItem>();
        }
    }

    public class SaleItem
    {
        public required string ProductId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue => Quantity * UnitPrice - Discount;
    }
}