using ProductInventory.Application.Interfaces;

namespace ProductInventory.Application.UseCases.Inventory.Delete
{
    public class DeleteInventoryHandler
    {
        private readonly IInventoryRepository _inventoryRepository;
        public DeleteInventoryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(int id)
        {
            var repo = await _inventoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("not found");
            await _inventoryRepository.DeleteAsync(repo);
        }
    }
}
