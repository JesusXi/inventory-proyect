using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.Inventory.Delete;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.Inventory
{
    public class DeleteInventaoryTest
    {
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly DeleteInventoryHandler _handler;
        public DeleteInventaoryTest()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _handler = new DeleteInventoryHandler(_inventoryRepositoryMock.Object);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Delete_Inventory_When_Exists()
        {
            var inventory = new InventoryVM(1, 10, 5, 20);
            _inventoryRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(inventory);
            await _handler.ExecuteAsync(1);
            _inventoryRepositoryMock.Verify(r => r.DeleteAsync(inventory), Times.Once);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Throw_When_Inventory_Not_Found()
        {
            _inventoryRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((InventoryVM?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.ExecuteAsync(99));
        }
    }
}
