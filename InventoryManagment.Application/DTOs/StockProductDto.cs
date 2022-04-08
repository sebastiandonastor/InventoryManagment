namespace InventoryManagment.Application.DTOs
{
    public class StockProductDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDto Product { get; set; } = null!;
        public VendorDto Vendor { get; set; } = null!;

    }
}
