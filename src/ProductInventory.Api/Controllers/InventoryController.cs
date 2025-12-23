using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Application.UseCases.Inventory.Create;
using ProductInventory.Application.UseCases.Inventory.Delete;
using ProductInventory.Application.UseCases.Inventory.Get;
using ProductInventory.Application.UseCases.Inventory.Update;
namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetInventoryHandler handler, [FromQuery] int productId)
        {
            var result = await handler.ExecuteAsync(productId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateInventoryHandler handler, [FromBody] CreateInventoryCommand command)
        {
            await handler.ExecuteAsync(command);
            return Created("", null);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromServices] UpdateInventoryHandler handler, [FromBody] UpdateInventoryCommand command)
        {
            await handler.ExecuteAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DeleteInventoryHandler handler)
        {
            await handler.ExecuteAsync(id);
            return NoContent();
        }
    }
}
