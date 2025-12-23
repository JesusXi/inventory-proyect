using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface IInventoryRepository
    {
        Task<InventoryVM?> GetByIdAsync(int id);
        Task<IEnumerable<InventoryVM>> GetByProductIdAsync(int productId);
        Task AddAsync(InventoryVM inventory);
        Task UpdateAsync(InventoryVM inventory);
        Task DeleteAsync(InventoryVM inventory);
    }
}
