using InventoryManagment.Application.DTOs;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductDto ProductDto { get; set; } = null!;
    }
}
