using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductInventory.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;
        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<InventoryVM?> GetByIdAsync(int id)
        {
            return await _context.Inventory.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<InventoryVM>> GetByProductIdAsync(int IdProduct)
        {
            return await _context.Inventory.Where(x => x.IdProduct == IdProduct).ToListAsync();
        }
        public async Task AddAsync(InventoryVM inventory)
        {
            await _context.Inventory.AddAsync(inventory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(InventoryVM inventory)
        {
            _context.Inventory.Update(inventory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(InventoryVM inventory)
        {
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}