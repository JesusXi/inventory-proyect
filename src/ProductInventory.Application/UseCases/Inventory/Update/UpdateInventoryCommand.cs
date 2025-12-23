namespace ProductInventory.Application.UseCases.Inventory.Update
{
    public record UpdateInventoryCommand(int IdProduct, int Stock, int StockMax, int StockMin);
}
