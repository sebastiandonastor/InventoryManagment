using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Extensions;
using InventoryManagment.Application.Features.Products.Requests;
using InventoryManagment.Application.Persistence.Contracts;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace InventoryManagment.Application.Features.Products.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private IDistributedCache _distributedCache;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache distributedCache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var key = "productList";
            var products = await _distributedCache.GetRecordAsync<List<ProductDto>>(key);

            if (products is null)
            {
                products = _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
                await _distributedCache.SetRecordAsync(key, products);
            }

            return products;
        }
    }
}
