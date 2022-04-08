namespace InventoryManagment.Application.Responses
{
    public class CommandResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = null!;
    }
}
