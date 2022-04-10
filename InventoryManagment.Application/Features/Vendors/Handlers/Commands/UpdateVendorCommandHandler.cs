using AutoMapper;
using InventoryManagment.Application.Features.Vendors.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        public UpdateVendorCommandHandler(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }

        public async Task<Unit> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.GetAsync(request.VendortDto.Id);
            _mapper.Map(request.VendortDto, vendor);

            await _vendorRepository.UpdateAsync(vendor);

            return Unit.Value;
        }
    }
}
