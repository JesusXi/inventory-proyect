using ProductCatCategory.Application.UseCases.CatCategory.Update;
using ProductInventory.Application.Interfaces;
using static ProductInventory.Domain.Entities.CatCategoryVM;
namespace ProductInventory.Application.UseCases.CatCategory.Update
{
    public class UpdateCatCategoryHandler
    {
        private readonly ICatCategoryRepository _catCategory;
        public UpdateCatCategoryHandler(ICatCategoryRepository catCategory)
        {
            _catCategory = catCategory;
        }
        public async Task ExecuteAsync(int id, UpdateCatCategoryCommand command)
        {
            var repo = await _catCategory.GetByIdAsync(id) ?? throw new KeyNotFoundException("not found");
            var stockUpdate = new CategoryUpdate(command.name, command.description);
            repo.Update(stockUpdate);
            await _catCategory.UpdateAsync(repo);
        }
    }
}
