using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Responses;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<CommandResponse>
    {
        public ProductDto Product { get; set; } = null!;
    }
}
