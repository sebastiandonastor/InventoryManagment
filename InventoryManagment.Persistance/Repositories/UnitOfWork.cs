using InventoryManagment.Application.Constants.Claims;
using InventoryManagment.Application.Contracts.Persistence;
using InventoryManagment.Application.Persistence.Contracts;
using Microsoft.AspNetCore.Http;

namespace InventoryManagment.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly InventoryManagmentDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IProductRepository _productRepository;
        private IVendorRepository _vendorRepository;


        public UnitOfWork(InventoryManagmentDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);
        public IVendorRepository VendorRepository =>
            _vendorRepository ??= new VendorRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
