using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Requests
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
    }
}
