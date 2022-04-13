using InventoryManagment.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                new ApplicationRole
                {
                    Id = Guid.Parse("5426304e-003f-46dc-a6ee-78b0416e67fd"),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("47493753-b45e-4332-87ee-8af09b9bfd66"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
