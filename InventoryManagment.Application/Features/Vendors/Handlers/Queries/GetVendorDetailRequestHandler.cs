using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Features.Vendors.Requests.Queries;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Handlers.Queries
{
    public class GetVendorDetailRequestHandler : IRequestHandler<GetVendorDetailRequest, VendorDto>
    {
        private readonly IMapper _mapper;
        private IVendorRepository _vendorRepository;

        public GetVendorDetailRequestHandler(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;

        }

        public async Task<VendorDto> Handle(GetVendorDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<VendorDto>(await _vendorRepository.GetAsync(request.Id));

        }
    }
}

