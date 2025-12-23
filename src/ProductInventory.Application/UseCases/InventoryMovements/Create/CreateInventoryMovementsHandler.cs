using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.InventoryMovements.Create
{
    public class CreateInventoryMovementsHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IInventoryMovementsRepository _movementRepository;
        public CreateInventoryMovementsHandler(
            IUserRepository userRepository,
            IInventoryRepository inventoryRepository,
            IInventoryMovementsRepository movementRepository)
        {
            _userRepository = userRepository;
            _inventoryRepository = inventoryRepository;
            _movementRepository = movementRepository;
        }
        public async Task ExecuteAsync(Guid userId, CreateInventoryMovementsCommand command)
        {
            var user = await _userRepository.GetByIdAsync(userId) ?? throw new UnauthorizedAccessException("User not found");
            var inventory = await _inventoryRepository.GetByIdAsync(command.IdProduct);
            if (inventory == null)
                throw new InvalidOperationException("Inventory not found for this product");
            var newQuantity = inventory.Stock + command.Motion;
            if (newQuantity < 0)
                throw new InvalidOperationException("Inventory cannot be negative");
            var movement = new InventoryMovementsVM(
                user.User,
                command.IdProduct,
                command.Motion
            );
            await _movementRepository.AddAsync(movement);
        }
    }
}
