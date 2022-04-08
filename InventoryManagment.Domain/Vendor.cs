using InventoryManagment.Domain.Common;

namespace InventoryManagment.Domain
{
    public class Vendor : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<StockProduct> StockProducts { get; set; } = null!;
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastModifiedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}