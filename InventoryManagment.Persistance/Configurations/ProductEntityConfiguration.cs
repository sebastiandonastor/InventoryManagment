using InventoryManagment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Persistance.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Furhaven Orthopedic, Memory Foam, & Cooling Gel Pet Beds for Small/Medium/Large Dogs & Cats, Plush Southwest Kilim Sofa Style, Removable Washable Cover - Multiple Colors & Sizes",
                    Description = "A comfy dog bed"
                },
                new Product
                {
                    Id = 2,
                    Name = "Good'N'Fun Triple Flavored Rawhide Kabobs for Dogs",
                    Description = "Yummy treats for dogs (not for humans)"
                });

        }
    }
}
