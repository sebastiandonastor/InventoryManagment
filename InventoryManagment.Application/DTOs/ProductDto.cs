namespace InventoryManagment.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<StockProductDto> StockProducts { get; set; } = null!;
    }
}
