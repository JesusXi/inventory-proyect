using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.CatCategory.Create
{
    public class CreateCatCategoryHandler
    {
        private readonly ICatCategoryRepository _catCategory;
        public CreateCatCategoryHandler(ICatCategoryRepository catCategory)
        {
            _catCategory = catCategory;
        }
        public async Task ExecuteAsync(CreateCatCategoryCommand command)
        {
            var movement = new CatCategoryVM(command.catCategory.Name, command.catCategory.Description);
            await _catCategory.AddAsync(movement);
        }
    }
}
