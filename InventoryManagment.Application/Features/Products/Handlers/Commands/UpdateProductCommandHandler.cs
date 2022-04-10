using AutoMapper;
using InventoryManagment.Application.Exceptions;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Validators.Product;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var product = await _productRepository.GetAsync(request.ProductDto.Id);

            if (product is null)
                throw new NotFoundException(nameof(product), request.ProductDto.Id);

            _mapper.Map(request.ProductDto, product);

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
