using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Commands
{
    public class UpdateVendorCommand : IRequest<Unit>
    {
        public VendorDto VendortDto { get; set; } = null!;
    }
}
