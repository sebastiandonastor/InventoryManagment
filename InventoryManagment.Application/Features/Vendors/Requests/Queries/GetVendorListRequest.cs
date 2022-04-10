using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Requests.Queries
{
    public class GetVendorListRequest : IRequest<List<VendorDto>>
    {
    }
}
