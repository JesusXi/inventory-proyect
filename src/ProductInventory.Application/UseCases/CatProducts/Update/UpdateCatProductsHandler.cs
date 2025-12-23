using ProductInventory.Application.Interfaces;
using ProductInventory.Application.UseCases.CatProducts.Update;
using ProductInventory.Domain.Entities;
namespace ProductCatProducts.Application.UseCases.CatProducts.Create
{
    public class UpdateCatProductsHandler
    {
        private readonly ICatProductsRepository _CatProductsRepository;
        public UpdateCatProductsHandler(ICatProductsRepository CatProductsRepository)
        {
            _CatProductsRepository = CatProductsRepository;
        }
        public async Task ExecuteAsync(UpdateCatProductsCommand command)
        {
            var movement = new CatProductsVM(command.catProducts.IdCategory, command.catProducts.Name, command.catProducts.Description);
            await _CatProductsRepository.UpdateAsync(movement);
        }
    }
}
