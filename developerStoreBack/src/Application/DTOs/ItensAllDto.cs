using DeveloperStoreBack.Domain.Entities;

namespace DeveloperStoreBack.Application.DTOs
{
    public class ItensAllDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Categoria { get; set; }
        public string Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }

        public static ItensAllDto FromItem(Item item)
        {
            return new ItensAllDto
            {
                Id = item.Id.ToString(),
                ProductId = item.ProductId,
                Categoria = item.Categoria,
                Image = item.Image,
                UnitPrice = item.UnitPrice,
                StockQuantity = item.StockQuantity
            };
        }
    }
}