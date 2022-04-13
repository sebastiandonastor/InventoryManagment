using InventoryManagment.Application.Models.Identity;

namespace InventoryManagment.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetCustomers();
        Task<User> GetCustomer(Guid userId);
    }
}
