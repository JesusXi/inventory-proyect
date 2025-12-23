using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.CatCategory.Get
{
    public class GetCatCategoryHandler
    {
        private readonly ICatCategoryRepository _catCategory;
        public GetCatCategoryHandler(ICatCategoryRepository inventoryRepository)
        {
            _catCategory = inventoryRepository;
        }
        public async Task<IEnumerable<CatCategoryVM>> ExecuteAsync(bool acivo = true)
        {
            return await _catCategory.GetByStatusAsync(acivo);
        }
    }
}
