using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.CatProducts.Create
{
    public class CreateCatProductsHandler
    {
        private readonly ICatProductsRepository _catProductsRepository;
        public CreateCatProductsHandler(ICatProductsRepository catProductsRepository)
        {
            _catProductsRepository = catProductsRepository;
        }
        public async Task ExecuteAsync(CreateCatProductsCommand command)
        {
            var movement = new CatProductsVM(command.catProducts.IdCategory, command.catProducts.Name, command.catProducts.Description);
            await _catProductsRepository.AddAsync(movement);
        }
    }
}
