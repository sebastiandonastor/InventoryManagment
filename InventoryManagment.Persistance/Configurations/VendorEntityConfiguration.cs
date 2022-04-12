using InventoryManagment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Persistance.Configurations
{
    public class VendorEntityConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor");
            
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
