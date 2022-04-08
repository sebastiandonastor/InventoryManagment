using InventoryManagment.Domain.Common;

namespace InventoryManagment.Domain
{
    public class StockProduct : IDomainEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; } = null!;
        public Vendor Vendor { get; set; } = null!;
        public string CreatedBy { get; set; } = string.Empty;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
