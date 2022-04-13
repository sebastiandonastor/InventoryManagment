using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Features.Products.Queries;
using InventoryManagment.Application.Features.Products.Requests;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Profiles;
using InventoryManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagment.Application.UnitTests.Products.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetProductListRequestHandlerTests()
        {
            _mockRepo = MockProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
