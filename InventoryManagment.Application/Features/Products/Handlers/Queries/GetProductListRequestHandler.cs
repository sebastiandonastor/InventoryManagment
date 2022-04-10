using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Features.Products.Requests;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
           return _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
        }
    }
}
