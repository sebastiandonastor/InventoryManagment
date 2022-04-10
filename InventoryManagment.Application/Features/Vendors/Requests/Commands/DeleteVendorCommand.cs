using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Commands
{
    public class DeleteVendorCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
