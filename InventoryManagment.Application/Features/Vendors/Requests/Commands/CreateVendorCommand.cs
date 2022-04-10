using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Commands
{
    public class CreateVendorCommand : IRequest<int>
    {
        public VendorDto VendorDto { get; set; } = null!;
    }
}
