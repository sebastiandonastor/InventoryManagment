using AutoMapper;
using InventoryManagment.Application.Exceptions;
using InventoryManagment.Application.Features.Vendors.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Validators.Product;
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
            var validator = new UpdateVendorValidator();
            var validationResult = await validator.ValidateAsync(request.VendortDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var vendor = await _vendorRepository.GetAsync(request.VendortDto.Id);
            _mapper.Map(request.VendortDto, vendor);

            if (vendor is null)
                throw new NotFoundException(nameof(vendor), request.VendortDto.Id);

            await _vendorRepository.UpdateAsync(vendor);

            return Unit.Value;
        }
    }
}
