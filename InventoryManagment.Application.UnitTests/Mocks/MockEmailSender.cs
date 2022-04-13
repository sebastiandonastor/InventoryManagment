using InventoryManagment.Application.Contracts.Infrastructure;
using Moq;

namespace InventoryManagment.Application.UnitTests.Mocks
{
    public static class MockEmailSender
    {
        public static Mock<IEmailSender> GetEmailSender()
        {
            return new Mock<IEmailSender>();
        }

    }
}
