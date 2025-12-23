using Moq;
using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.InventoryMovements.Create;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Tests.InventoryMovements
{
    public class CreateInventaoryMovementsTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IInventoryRepository> _inventoryRepository;
        private readonly Mock<IInventoryMovementsRepository> _movementRepository;
        private readonly CreateInventoryMovementsHandler _handler;
        public CreateInventaoryMovementsTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _inventoryRepository = new Mock<IInventoryRepository>();
            _movementRepository = new Mock<IInventoryMovementsRepository>();
            _handler = new CreateInventoryMovementsHandler(_userRepository.Object, _inventoryRepository.Object, _movementRepository.Object);
        }
        [Fact]
        public async Task ExecuteAsync_Should_Create_Movement_When_Data_Is_Valid()
        {
            var userId = Guid.NewGuid();
            var command = new CreateInventoryMovementsCommand(IdProduct: 1, Motion: 5);
            var user = new UsersVM("test@mail.com", new byte[] { 1, 2, 3 });
            typeof(UsersVM).GetProperty("User")!.SetValue(user, 1001);
            var inventory = new InventoryVM(idProduct: 1, stock: 10, stockMin: 0, stockMax: 100);
            _userRepository.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
            _inventoryRepository.Setup(r => r.GetByIdAsync(command.IdProduct)).ReturnsAsync(inventory);
            await _handler.ExecuteAsync(userId, command);
            _movementRepository.Verify(r => r.AddAsync(It.Is<InventoryMovementsVM>(m => m.UserId == user.User && m.IdProduct == command.IdProduct && m.Motion == command.Motion)), Times.Once);
        }
    }
}