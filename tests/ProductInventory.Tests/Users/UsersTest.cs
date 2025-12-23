using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.User;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.Users
{
    public class UsersTest
    {
        [Fact]
        public async Task CreateUser_Should_Save_User_With_Hashed_Password()
        {
            var repoMock = new Mock<IUserRepository>();
            var passMock = new Mock<IPassService>();
            passMock.Setup(p => p.Hash(It.IsAny<string>())).Returns(new byte[] { 1, 2, 3 });
            var handler = new UserHandler(repoMock.Object, passMock.Object);
            var command = new UserCommand("test@mail.com", "123");
            await handler.ExecuteAsync(command);
            repoMock.Verify(r => r.AddAsync(It.Is<UsersVM>(u => u.Password.Length > 0)), Times.Once);
        }
    }
}
