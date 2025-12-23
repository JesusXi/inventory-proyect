namespace ProductInventory.Domain.Entities
{
    public class InventoryVM
    {
        public int Id { get; private set; }
        public int IdProduct { get; private set; }
        public int Stock { get; private set; }
        public int StockMax { get; private set; }
        public int StockMin { get; private set; }
        private InventoryVM() { }
        public record InventoryStockUpdate(int Stock, int StockMin, int StockMax);
        public InventoryVM(int idProduct, int stock, int stockMax, int stockMin)
        {
            IdProduct = idProduct;
            Stock = stock;
            StockMax = stockMax;
            StockMin = stockMin;
        }
        public void UpdateStock(InventoryStockUpdate update)
        {
            if (update.Stock < 0)
                throw new ArgumentException("Stock cannot be negative");
            if (update.StockMin < 0)
                throw new ArgumentException("StockMin cannot be negative");
            if (update.StockMax < 0)
                throw new ArgumentException("StockMax cannot be negative");
            if (update.StockMin > update.StockMax)
                throw new ArgumentException("StockMin cannot be greater than StockMax");
            if (update.Stock < update.StockMin || update.Stock > update.StockMax)
                throw new ArgumentException("Stock must be between StockMin and StockMax");
            Stock = update.Stock;
            StockMin = update.StockMin;
            StockMax = update.StockMax;
        }
    }
}