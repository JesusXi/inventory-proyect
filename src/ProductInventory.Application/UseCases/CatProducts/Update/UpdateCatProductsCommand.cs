using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.CatProducts.Update
{
    public record UpdateCatProductsCommand(CatProductsVM catProducts);
}
