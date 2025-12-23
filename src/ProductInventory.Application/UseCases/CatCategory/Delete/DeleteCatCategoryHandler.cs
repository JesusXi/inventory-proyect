using ProductInventory.Application.Interfaces;
namespace ProductInventory.Application.UseCases.CatCategory.Delete
{
    public class DeleteCatCategoryHandler
    {
        private readonly ICatCategoryRepository _catCategoryRepository;
        public DeleteCatCategoryHandler(ICatCategoryRepository CatCategoryRepository)
        {
            _catCategoryRepository = CatCategoryRepository;
        }
        public async void ExecuteAsync(int id)
        {
            var repo = await _catCategoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("not found");
            await _catCategoryRepository.DeleteAsync(repo);
        }
    }
}
