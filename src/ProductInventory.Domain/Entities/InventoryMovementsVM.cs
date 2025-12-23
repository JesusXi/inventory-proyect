namespace ProductInventory.Domain.Entities
{
    public class InventoryMovementsVM
    {
        public int Id { get; private set; }
        public int IdProduct { get; private set; }
        public int UserId { get; private set; }
        public int Motion { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private InventoryMovementsVM() { }
        public InventoryMovementsVM(int userId, int idProduct, int motion)
        {
            UserId = userId;
            IdProduct = idProduct;
            Motion = motion;
        }
    }
}
