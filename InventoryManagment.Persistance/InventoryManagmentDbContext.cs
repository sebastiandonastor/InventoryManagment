using InventoryManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Persistance
{
    public class InventoryManagmentDbContext : AuditableDbContext
    {
        public InventoryManagmentDbContext(DbContextOptions<InventoryManagmentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryManagmentDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
    }
}
