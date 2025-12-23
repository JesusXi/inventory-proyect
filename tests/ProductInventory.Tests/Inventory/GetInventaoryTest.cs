using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.Inventory.Get;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.Inventory
{
    public class GetInventoryTest
    {
        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly GetInventoryHandler _handler;
        public GetInventoryTest()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _handler = new GetInventoryHandler(_inventoryRepositoryMock.Object);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Return_Inventory_List_When_Data_Exists()
        {
            var inventories = new List<InventoryVM>
            {
                new InventoryVM(1, 10, 5, 20),
                new InventoryVM(1, 8, 3, 15)
            };
            _inventoryRepositoryMock.Setup(r => r.GetByProductIdAsync(It.IsAny<int>())).ReturnsAsync(inventories);
            var result = await _handler.ExecuteAsync(1);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task ExecuteAsync_Should_Return_Empty_List_When_No_Data()
        {
            _inventoryRepositoryMock.Setup(r => r.GetByProductIdAsync(It.IsAny<int>())).ReturnsAsync(new List<InventoryVM>());
            var result = await _handler.ExecuteAsync(99);
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}