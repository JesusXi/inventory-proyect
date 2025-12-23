using System.Text;
using Microsoft.Extensions.Configuration;
using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Tests.Helpers;
namespace ProductInventory.Application.UseCases.Login
{
    public class LoginHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_Return_Token()
        {
            var hashedPassword = Encoding.UTF8.GetBytes("hashed-password");
            var user = new UsersVM("test@mail.com", hashedPassword);
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            var sessionRepo = new Mock<ISessionRepository>();
            sessionRepo.Setup(x => x.GetByUserIdAsync(user.Id)).ReturnsAsync((SessionVM?)null);
            var passService = new Mock<IPassService>();
            passService.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(true);
            var config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "THIS_IS_A_VERY_SECURE_KEY_123456789",
                ["Jwt:Issuer"] = "TestIssuer",
                ["Jwt:Audience"] = "TestAudience"
            }).Build();
            var handler = new LoginHandler(userRepo.Object, sessionRepo.Object, passService.Object, config);
            var command = new LoginCommand("test@mail.com", "123456");
            var result = await handler.ExecuteAsync(command);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Token));
            Assert.True(result.ExpiresAt > DateTime.UtcNow);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Throw_When_Email_Not_Exists()
        {
            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((UsersVM?)null);
            var handler = new LoginHandler(repoMock.Object, Mock.Of<ISessionRepository>(), Mock.Of<IPassService>(), TestConfiguration.CreateJwtConfig());
            var command = new LoginCommand("fake@mail.com", "123");
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => handler.ExecuteAsync(command));
        }
    }
}
