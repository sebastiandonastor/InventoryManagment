using AutoMapper;
using InventoryManagment.Application.Features.Vendors.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Domain;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Handlers.Commands
{
    public class CreateVendorCommmandHandler : IRequestHandler<CreateVendorCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        public CreateVendorCommmandHandler(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }
        public async Task<int> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = _mapper.Map<Vendor>(request.VendorDto);

            await _vendorRepository.AddAsync(vendor);

            return vendor.Id;
        }
    }
}
