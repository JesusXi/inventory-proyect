using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface IInventoryMovementsRepository
    {
        Task<IEnumerable<InventoryMovementsVM>> GetByUserAsync(int userId);
        Task<IEnumerable<InventoryMovementsVM>> GetByPsroductIdAsync(int productId);
        Task<IEnumerable<InventoryMovementsVM>> GetByProductByUserAsync(int productId, int userId);
        Task<IEnumerable<InventoryMovementsVM>> GetByProductByUserByDateAsync(int IdProduct, int userId, DateTime start, DateTime end);
        Task<IEnumerable<InventoryMovementsVM>> GetByProductByDateAsync(int IdProduct, DateTime start, DateTime end);
        Task<IEnumerable<InventoryMovementsVM>> GetByUserByDateAsync(int userId, DateTime start, DateTime end);
        Task<InventoryMovementsVM?> GetByIdAsync(int id);
        Task AddAsync(InventoryMovementsVM inventoryMovement);
    }
}
