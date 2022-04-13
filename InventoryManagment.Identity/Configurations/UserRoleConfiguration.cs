using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("47493753-b45e-4332-87ee-8af09b9bfd66"),
                    UserId = Guid.Parse("90594f9d-3678-4f94-a017-6a0168264fa7")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("5426304e-003f-46dc-a6ee-78b0416e67fd"),
                    UserId = Guid.Parse("259960ad-8662-4824-aa6c-b2bb6282e688")
                }
            );
        }
    }
}
