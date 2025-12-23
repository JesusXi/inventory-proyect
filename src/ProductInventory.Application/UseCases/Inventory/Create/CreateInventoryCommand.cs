using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.Inventory.Create
{
    public record CreateInventoryCommand(InventoryVM inventory);
}
