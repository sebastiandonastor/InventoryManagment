using InventoryManagment.Application.Features.Vendors.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, Unit>
    {
        private readonly IVendorRepository _vendorRepository;

        public DeleteVendorCommandHandler(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var product = await _vendorRepository.GetAsync(request.Id);

            await _vendorRepository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}
