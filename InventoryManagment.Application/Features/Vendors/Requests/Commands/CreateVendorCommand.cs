using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Responses;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Commands
{
    public class CreateVendorCommand : IRequest<CommandResponse>
    {
        public VendorDto VendorDto { get; set; } = null!;
    }
}
