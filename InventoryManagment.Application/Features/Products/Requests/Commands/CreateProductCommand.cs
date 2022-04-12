using InventoryManagment.Application.DTOs.Product;
using InventoryManagment.Application.Responses;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<CommandResponse>
    {
        public CreateProductDto ProductDto { get; set; } = null!;
    }
}
