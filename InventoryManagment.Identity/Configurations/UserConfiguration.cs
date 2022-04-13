using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventoryManagment.Identity.Models;

namespace InventoryManagment.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = Guid.Parse("90594f9d-3678-4f94-a017-6a0168264fa7"),
                     Email = "admin@gmail.com",
                     NormalizedEmail = "ADMIN@GMAIL.COM",
                     FirstName = "Master",
                     LastName = "Admin",
                     UserName = "admin@gmail.com",
                     NormalizedUserName = "ADMIN@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null!, "Dogs1234*"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString()
                 },
                 new ApplicationUser
                 {
                     Id = Guid.Parse("259960ad-8662-4824-aa6c-b2bb6282e688"),
                     Email = "sebasdoglover@gmail.com",
                     NormalizedEmail = "SEBASDOGLOVER@GMAIL.COM",
                     FirstName = "Sebastian",
                     LastName = "Dogs",
                     UserName = "sebasdoglover@gmail.com",
                     NormalizedUserName = "SEBASDOGLOVER@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null!, "Dogs1234*"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString()
                 }
            );
        }

    }
}
