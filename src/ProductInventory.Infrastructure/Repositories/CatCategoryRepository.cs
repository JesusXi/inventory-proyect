using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductCatCategory.Infrastructure.Repositories
{
    public class CatCategoryRepository : ICatCategoryRepository
    {
        private readonly AppDbContext _context;
        public CatCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CatCategoryVM?> GetByIdAsync(int id)
        {
            return await _context.CatCategory.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<CatCategoryVM>> GetByNameAsync(string name)
        {
            return await _context.CatCategory.Where(x => x.Name == name).OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<CatCategoryVM>> GetByStatusAsync(bool active)
        {
            return await _context.CatCategory.Where(x => x.Active == active).OrderBy(x => x.EdithAt).ToListAsync();
        }
        public async Task<IEnumerable<CatCategoryVM>> GetByDateAsync(DateTime date)
        {
            return await _context.CatCategory.Where(x => x.EdithAt == date && x.Active == true).OrderBy(x => x.EdithAt).ToListAsync();
        }
        public async Task AddAsync(CatCategoryVM CatCategory)
        {
            await _context.CatCategory.AddAsync(CatCategory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CatCategoryVM CatCategory)
        {
            _context.CatCategory.Update(CatCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(CatCategoryVM CatCategory)
        {
            CatCategory.Deactivate();
            await _context.SaveChangesAsync();
        }
    }
}