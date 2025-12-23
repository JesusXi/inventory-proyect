using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface ICatCategoryRepository
    {
        Task<CatCategoryVM?> GetByIdAsync(int id);
        Task<IEnumerable<CatCategoryVM>> GetByNameAsync(string name);
        Task<IEnumerable<CatCategoryVM>> GetByStatusAsync(bool active);
        Task<IEnumerable<CatCategoryVM>> GetByDateAsync(DateTime date);
        Task AddAsync(CatCategoryVM catCategor);
        Task UpdateAsync(CatCategoryVM catCategor);
        Task DeleteAsync(CatCategoryVM catCategor);
    }
}
