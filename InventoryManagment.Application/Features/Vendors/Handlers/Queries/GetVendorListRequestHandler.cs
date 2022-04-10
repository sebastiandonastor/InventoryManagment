using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Handlers.Queries
{
    public class GetVendorListRequestHandler : IRequestHandler<Requests.Queries.GetVendorListRequest, List<VendorDto>>
    {
        private readonly IMapper _mapper;
        private IVendorRepository _vendorRepository;

        public GetVendorListRequestHandler(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;

        }
        public async Task<List<VendorDto>> Handle(Requests.Queries.GetVendorListRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<VendorDto>>(await _vendorRepository.GetAll());
        }
    }
}
