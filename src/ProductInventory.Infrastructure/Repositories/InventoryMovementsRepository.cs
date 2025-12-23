using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductInventory.Infrastructure.Repositories
{
    public class InventoryMovementsRepository : IInventoryMovementsRepository
    {
        private readonly AppDbContext _context;
        public InventoryMovementsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByUserAsync(int userId)
        {
            return await _context.InventoryMovements.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<InventoryMovementsVM?> GetByIdAsync(int id)
        {
            return await _context.InventoryMovements.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByPsroductIdAsync(int IdProduct)
        {
            return await _context.InventoryMovements.Where(x => x.IdProduct == IdProduct).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByProductByUserAsync(int IdProduct, int userId)
        {
            return await _context.InventoryMovements.Where(x => x.IdProduct == IdProduct && x.UserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByProductByUserByDateAsync(int IdProduct, int userId, DateTime start, DateTime end)
        {
            return await _context.InventoryMovements.Where(x => x.IdProduct == IdProduct && x.UserId == userId && (x.CreatedAt >= start && x.CreatedAt <= end)).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByProductByDateAsync(int IdProduct, DateTime start, DateTime end)
        {
            return await _context.InventoryMovements.Where(x => x.IdProduct == IdProduct && (x.CreatedAt >= start && x.CreatedAt <= end)).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<IEnumerable<InventoryMovementsVM>> GetByUserByDateAsync(int userId, DateTime start, DateTime end)
        {
            return await _context.InventoryMovements.Where(x => x.UserId == userId && (x.CreatedAt >= start && x.CreatedAt <= end)).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task AddAsync(InventoryMovementsVM inventory)
        {
            await _context.InventoryMovements.AddAsync(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
