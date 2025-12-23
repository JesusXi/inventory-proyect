using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.Inventory.Create
{
    public class CreateInventoryHandler
    {
        private readonly IInventoryRepository _inventoryRepository;
        public CreateInventoryHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(CreateInventoryCommand command)
        {
            var movement = new InventoryVM(command.inventory.IdProduct, command.inventory.Stock, command.inventory.StockMax, command.inventory.StockMin);
            await _inventoryRepository.AddAsync(movement);
        }
    }
}
