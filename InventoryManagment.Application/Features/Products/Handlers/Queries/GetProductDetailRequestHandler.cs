using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Features.Products.Requests;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetAsync(request.Id));
        }
    }
}
