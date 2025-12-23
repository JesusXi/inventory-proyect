using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.InventoryMovements.Get
{
    public class GetInventoryMovementsHandler
    {
        private readonly IInventoryMovementsRepository _inventoryMovementRepository;
        private readonly IUserRepository _usersRepository;
        public GetInventoryMovementsHandler(IInventoryMovementsRepository inventoryMovementRepository, IUserRepository usersRepository)
        {
            _inventoryMovementRepository = inventoryMovementRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<InventoryMovementsVM>> ExecuteAsync(Guid userId)
        {
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new UnauthorizedAccessException("User not found");
            return await _inventoryMovementRepository.GetByUserAsync(user.User);
        }
    }
}
