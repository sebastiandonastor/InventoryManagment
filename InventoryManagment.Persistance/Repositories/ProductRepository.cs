using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Domain;

namespace InventoryManagment.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly InventoryManagmentDbContext _dbContext;

        public ProductRepository(InventoryManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
