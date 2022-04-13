using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace InventoryManagment.Application.UnitTests.Mocks
{
    public static class MockHttpContextAccesor
    {
        public static Mock<IHttpContextAccessor> GetContextAccesor()
        {
            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            mockHttpContextAccessor.Setup(m => m.HttpContext.User.FindFirst(It.IsAny<string>()))
                .Returns(It.IsAny<Claim>());

            return mockHttpContextAccessor;
        }
    }
}
