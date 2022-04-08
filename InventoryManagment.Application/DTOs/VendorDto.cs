namespace InventoryManagment.Application.DTOs
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<StockProductDto> StockProducts { get; set; } = null!;
    }
}
