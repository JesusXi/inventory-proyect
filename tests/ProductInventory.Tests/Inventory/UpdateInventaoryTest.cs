using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.Inventory.Update;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.Inventory
{
    public class UpdateInventoryTest
    {
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly UpdateInventoryHandler _handler;
        public UpdateInventoryTest()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _handler = new UpdateInventoryHandler(_inventoryRepositoryMock.Object);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Update_Inventory_When_Exists()
        {
            var inventory = new InventoryVM(idProduct: 1, stock: 10, stockMin: 5, stockMax: 20);
            var command = new UpdateInventoryCommand(IdProduct: 1, Stock: 15, StockMin: 7, StockMax: 30);
            _inventoryRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(inventory);
            await _handler.ExecuteAsync(1, command);
            _inventoryRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<InventoryVM>()), Times.Once);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Throw_When_Inventory_Not_Found()
        {
            var command = new UpdateInventoryCommand(1, 10, 5, 20);
            _inventoryRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((InventoryVM?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.ExecuteAsync(99, command));
        }
    }
}