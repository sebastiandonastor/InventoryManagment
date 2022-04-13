using InventoryManagment.Application.Persistence.Contracts;

namespace InventoryManagment.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IVendorRepository VendorRepository { get; }
        Task Save();
    }
}
