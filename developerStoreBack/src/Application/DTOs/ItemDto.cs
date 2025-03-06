namespace DeveloperStoreBack.Application.DTOs
{
    public class ItemDto
    {
        public required string Id { get; set; }
        public required string ProductId { get; set; }
        public required string Categoria { get; set; }
        public required string Image { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int StockQuantity { get; set; }

    }
}