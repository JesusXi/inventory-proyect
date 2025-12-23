using ProductInventory.Application.Interfaces;
namespace ProductInventory.Application.UseCases.CatProducts.Delete
{
    public class DeleteCatProductsHandler
    {
        private readonly ICatProductsRepository _catProductsHandler;
        public DeleteCatProductsHandler(ICatProductsRepository catProductsHandler)
        {
            _catProductsHandler = catProductsHandler;
        }
        public async void ExecuteAsync(int id)
        {
            var repo = await _catProductsHandler.GetByIdAsync(id) ?? throw new KeyNotFoundException("not found");
            await _catProductsHandler.DeleteAsync(repo);
        }
    }
}
