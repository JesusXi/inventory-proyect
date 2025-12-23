using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.Inventory.Create;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.Inventory
{
    public class CreateInventaoryTest
    {
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly CreateInventoryHandler _handler;
        public CreateInventaoryTest()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _handler = new CreateInventoryHandler(_inventoryRepositoryMock.Object);
        }
        [Fact]
        public async Task ExecuteAsync_WhenCommandIsValid_ShouldAddInventory()
        {
            var command = new CreateInventoryCommand(new InventoryVM(idProduct: 1, stock: 10, stockMax: 100, stockMin: 5));
            _inventoryRepositoryMock.Setup(r => r.AddAsync(It.IsAny<InventoryVM>())).Returns(Task.CompletedTask);
            await _handler.ExecuteAsync(command);
            _inventoryRepositoryMock.Verify(r => r.AddAsync(It.Is<InventoryVM>(i => i.IdProduct == 1 && i.Stock == 10 && i.StockMax == 100 && i.StockMin == 5)), Times.Once);
        }
        [Fact]
        public async Task ExecuteAsync_WhenRepositoryThrowsException_ShouldPropagateException()
        {
            var command = new CreateInventoryCommand(new InventoryVM(idProduct: 1, stock: 10, stockMax: 100, stockMin: 5));
            _inventoryRepositoryMock.Setup(r => r.AddAsync(It.IsAny<InventoryVM>())).ThrowsAsync(new Exception("Database error"));
            await Assert.ThrowsAsync<Exception>(() => _handler.ExecuteAsync(command));
        }
    }
}
