namespace DeveloperStoreBack.Application.DTOs
{
    public class ItemDto
    {
        public required string ProductId { get; set; }
        public required string Name { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int StockQuantity { get; set; }
    }
}