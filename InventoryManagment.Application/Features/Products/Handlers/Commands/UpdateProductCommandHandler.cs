using AutoMapper;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
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
            var product = await _productRepository.GetAsync(request.ProductDto.Id);
            _mapper.Map(request.ProductDto, product);

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
