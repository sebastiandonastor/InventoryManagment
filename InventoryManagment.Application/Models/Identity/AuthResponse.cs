namespace InventoryManagment.Application.Models.Identity
{
    public class AuthResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
