using AutoMapper;
using InventoryManagment.Application.Contracts.Persistence;
using InventoryManagment.Application.DTOs.Product;
using InventoryManagment.Application.Features.Products.Handlers.Commands;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Profiles;
using InventoryManagment.Application.Responses;
using InventoryManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagment.Application.UnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper, MockEmailSender.GetEmailSender().Object, MockHttpContextAccesor.GetContextAccesor().Object);

        }

        [Fact]
        public async Task Valid_Product_Added()
        {

            var result = await _handler.Handle(new CreateProductCommand() { ProductDto = new CreateProductDto { Name = "Dog's seat belt", Description = "A magic seat belt for a dog"  } }, CancellationToken.None);
            result.ShouldBeOfType<CommandResponse>();

            var products = await _mockUnitOfWork.Object.ProductRepository.GetAllAsync();

            products.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Invalid_Empty_Description_Product()
        {

            var result = await _handler.Handle(new CreateProductCommand() { ProductDto = new CreateProductDto { Name = "Dog's seat belt" } }, CancellationToken.None);
            result.ShouldBeOfType<CommandResponse>();
            result.Errors[0].ShouldBe("Description must not be empty.");
         
        }

        [Fact]
        public async Task Invalid_Duplicated_Product_Name()
        {

            var result = await _handler.Handle(new CreateProductCommand() { ProductDto = new CreateProductDto { Name = "Dog's Toy", Description = "Dog's best friend!" } }, CancellationToken.None);
            result.ShouldBeOfType<CommandResponse>();

        }

    }
}
