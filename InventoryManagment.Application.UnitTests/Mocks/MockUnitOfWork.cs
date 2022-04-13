using InventoryManagment.Application.Contracts.Persistence;
using Moq;

namespace InventoryManagment.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductRepository = MockProductRepository.GetProductRepository();

            mockUow.Setup(r => r.ProductRepository).Returns(mockProductRepository.Object);

            return mockUow;
        }
    }
}
