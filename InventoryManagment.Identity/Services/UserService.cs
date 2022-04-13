using InventoryManagment.Application.Contracts.Identity;
using InventoryManagment.Application.Models.Identity;
using InventoryManagment.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagment.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetCustomer(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return new User
            {
                Email = user.Email,
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName
            };
        }

        public async Task<List<User>> GetCustomers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            return users.Select(q => new User
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }
    }

}
