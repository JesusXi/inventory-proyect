using ProductInventory.Application.Interfaces;
using static ProductInventory.Domain.Entities.InventoryVM;
namespace ProductInventory.Application.UseCases.Inventory.Update
{
    public class UpdateInventoryHandler
    {
        private readonly IInventoryRepository _inventoryRepository;
        public UpdateInventoryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(int id, UpdateInventoryCommand command)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Inventory not found");
            var stockUpdate = new InventoryStockUpdate(
                command.Stock,
                command.StockMin,
                command.StockMax
            );
            inventory.UpdateStock(stockUpdate);
            await _inventoryRepository.UpdateAsync(inventory);
        }
    }
}
