using AutoMapper;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Responses;
using InventoryManagment.Application.Validators;
using InventoryManagment.Domain;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductValidator();
            var validationResult = await validator.ValidateAsync(request.Product);

            if (!validationResult.IsValid)
                return new CommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    Message = "Creation Failed"
                };

            var product = _mapper.Map<Product>(request.Product);
            await _productRepository.Add(product);

            return new CommandResponse()
            {
                Id = product.Id,
                Message = "Creation Succesful"
            };

        }
    }
}
