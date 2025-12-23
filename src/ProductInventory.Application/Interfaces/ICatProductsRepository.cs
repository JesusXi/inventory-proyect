using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface ICatProductsRepository
    {
        Task<CatProductsVM?> GetByIdAsync(int id);
        Task<IEnumerable<CatProductsVM>> GetByNameAsync(string name);
        Task<IEnumerable<CatProductsVM>> GetByIdCategoryAsync(int idCategoty);
        Task<IEnumerable<CatProductsVM>> GetByStatusAsync(bool active);
        Task<IEnumerable<CatProductsVM>> GetByDateAsync(DateTime date);
        Task AddAsync(CatProductsVM catProducts);
        Task UpdateAsync(CatProductsVM catProducts);
        Task DeleteAsync(CatProductsVM catProducts);
    }
}
