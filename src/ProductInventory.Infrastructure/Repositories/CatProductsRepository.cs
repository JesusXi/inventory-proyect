using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductCatProducts.Infrastructure.Repositories
{
    public class CaProductRepository : ICatProductsRepository
    {
        private readonly AppDbContext _context;
        public CaProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CatProductsVM?> GetByIdAsync(int id)
        {
            return await _context.CatProducts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<CatProductsVM>> GetByNameAsync(string name)
        {
            return await _context.CatProducts.Where(x => x.Name == name).OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<CatProductsVM>> GetByIdCategoryAsync(int idCategoty)
        {
            return await _context.CatProducts.Where(x => x.IdCategory == idCategoty && x.Active == true).OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<CatProductsVM>> GetByStatusAsync(bool active)
        {
            return await _context.CatProducts.Where(x => x.Active == active).OrderBy(x => x.EdithAt).ToListAsync();
        }
        public async Task<IEnumerable<CatProductsVM>> GetByDateAsync(DateTime date)
        {
            return await _context.CatProducts.Where(x => x.EdithAt == date && x.Active == true).OrderBy(x => x.EdithAt).ToListAsync();
        }
        public async Task AddAsync(CatProductsVM CatProducts)
        {
            await _context.CatProducts.AddAsync(CatProducts);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CatProductsVM CatProducts)
        {
            _context.CatProducts.Update(CatProducts);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(CatProductsVM CatProducts)
        {
            CatProducts.Deactivate();
            await _context.SaveChangesAsync();
        }
    }
}