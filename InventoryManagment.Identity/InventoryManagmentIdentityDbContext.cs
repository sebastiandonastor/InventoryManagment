using InventoryManagment.Identity.Configurations;
using InventoryManagment.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Identity
{
    public class InventoryManagmentIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public InventoryManagmentIdentityDbContext(DbContextOptions<InventoryManagmentIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }
}
