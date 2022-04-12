using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Domain;

namespace InventoryManagment.Persistance.Repositories
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly InventoryManagmentDbContext _dbContext;

        public VendorRepository(InventoryManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
