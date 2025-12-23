using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Application.UseCases.CatProducts.Create;
using ProductInventory.Application.UseCases.CatProducts.Delete;
using ProductInventory.Application.UseCases.CatProducts.Get;
using ProductInventory.Application.UseCases.Inventory.Update;


namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/Products")]
    [Authorize]
    public class CatProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetCatProductsHandler handler) => Ok(await handler.ExecuteAsync(true));
        [HttpPost("AddProduct")]
        public async Task<IActionResult> Create([FromServices] CreateCatProductsHandler handler, [FromBody] CreateCatProductsCommand command)
        {
            await handler.ExecuteAsync(command);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromServices] UpdateInventoryHandler handler, [FromBody] UpdateInventoryCommand command)
        {
            await handler.ExecuteAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DeleteCatProductsHandler handler)
        {
            handler.ExecuteAsync(id);
            return NoContent();
        }
    }
}
