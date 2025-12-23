using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.CatProducts.Get
{
    public class GetCatProductsHandler
    {
        private readonly ICatProductsRepository _catProductRepository;
        public GetCatProductsHandler(ICatProductsRepository catProductRepository)
        {
            _catProductRepository = catProductRepository;
        }
        public async Task<IEnumerable<CatProductsVM>> ExecuteAsync(bool catProductsActive = true)
        {
            return await _catProductRepository.GetByStatusAsync(catProductsActive);
        }
    }
}
