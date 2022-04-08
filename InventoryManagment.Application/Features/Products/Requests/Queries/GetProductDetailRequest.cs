using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Requests
{
    public class GetProductDetailRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
