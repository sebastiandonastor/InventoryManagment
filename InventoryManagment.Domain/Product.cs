using InventoryManagment.Domain.Common;

namespace InventoryManagment.Domain
{
    public class Product : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<StockProduct> StockProducts { get; set; } = null!;
        public string CreatedBy { get; set; } = string.Empty;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
