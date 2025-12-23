using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.InventoryMovements.Create;
using ProductInventory.Application.UseCases.InventoryMovements.Get;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.InventoryMovements
{
    public class GetInventaoryMovementsTest
    {
        private readonly Mock<IInventoryMovementsRepository> _inventoryMovementsRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetInventoryMovementsHandler _handler;
        public GetInventaoryMovementsTest()
        {
            _inventoryMovementsRepositoryMock = new Mock<IInventoryMovementsRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetInventoryMovementsHandler(_inventoryMovementsRepositoryMock.Object, _userRepositoryMock.Object);
        }
        [Fact]
        public async Task ExecuteAsync_WhenUserExists_ShouldReturnInventoryMovements()
        {
            var userId = Guid.NewGuid();
            var command = new CreateInventoryMovementsCommand(IdProduct: 1, Motion: 5);
            var user = new UsersVM("test@mail.com", new byte[] { 1, 2, 3 });
            typeof(UsersVM).GetProperty("User")!.SetValue(user, 1001);
            var movements = new List<InventoryMovementsVM>
            {
                new InventoryMovementsVM(1000,1,5),
            new InventoryMovementsVM(1000,1,5)
        };
            _userRepositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
            _inventoryMovementsRepositoryMock.Setup(r => r.GetByUserAsync(user.User)).ReturnsAsync(movements);
            var result = await _handler.ExecuteAsync(userId);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _inventoryMovementsRepositoryMock.Verify(r => r.GetByUserAsync(user.User), Times.Once);
        }
        [Fact]
        public async Task ExecuteAsync_WhenUserDoesNotExist_ShouldThrowUnauthorizedAccessException()
        {
            var userId = Guid.NewGuid();
            _userRepositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((UsersVM)null);
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _handler.ExecuteAsync(userId));
            _inventoryMovementsRepositoryMock.Verify(r => r.GetByUserAsync(It.IsAny<int>()), Times.Never);
        }
    }
}