namespace InventoryManagment.Domain.Common
{
    public interface IDomainEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
