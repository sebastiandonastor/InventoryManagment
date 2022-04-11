using AutoMapper;
using InventoryManagment.Application.Features.Vendors.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Responses;
using InventoryManagment.Application.Validators;
using InventoryManagment.Domain;
using MediatR;

namespace InventoryManagment.Application.Features.Vendors.Handlers.Commands
{
    public class CreateVendorCommmandHandler : IRequestHandler<CreateVendorCommand, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        public CreateVendorCommmandHandler(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }
        public async Task<CommandResponse> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateVendorValidator();
            var validationResult = await validator.ValidateAsync(request.VendorDto);

            if (!validationResult.IsValid)
                return new CommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    Message = "Creation Failed"
                };
            var vendor = _mapper.Map<Vendor>(request.VendorDto);

            await _vendorRepository.AddAsync(vendor);

            return new CommandResponse()
            {
                Id = vendor.Id,
                Message = "Creation Succesful"
            };
        }
    }
}
