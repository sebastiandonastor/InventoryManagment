using InventoryManagment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Persistance.Configurations
{
    public class StockProductEntityConfiguration : IEntityTypeConfiguration<StockProduct>
    {
        public void Configure(EntityTypeBuilder<StockProduct> builder)
        {
            builder.ToTable("StockProduct");

            builder.HasKey(sp => new {sp.ProductId, sp.VendorId});

            builder
                .Property(sp => sp.Price)
                .HasPrecision(22, 4);
            builder
                .HasOne(sp => sp.Product)
                .WithMany(p => p.StockProducts)
                .HasForeignKey(sp => sp.ProductId);

            builder
                .HasOne(sp => sp.Vendor)
                .WithMany(v => v.StockProducts)
                .HasForeignKey(sp => sp.VendorId);

        }
    }
}
