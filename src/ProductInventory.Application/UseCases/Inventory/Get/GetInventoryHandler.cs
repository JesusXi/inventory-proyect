using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.Inventory.Get
{
    public class GetInventoryHandler
    {
        private readonly IInventoryRepository _inventoryRepository;
        public GetInventoryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<InventoryVM>> ExecuteAsync(int productId)
        {
            return await _inventoryRepository.GetByProductIdAsync(productId);
        }
    }
}
