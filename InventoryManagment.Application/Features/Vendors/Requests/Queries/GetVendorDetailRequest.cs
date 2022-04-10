using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Queries
{
    public class GetVendorDetailRequest : IRequest<VendorDto>
    {
        public int Id { get; set; }
    }
}
