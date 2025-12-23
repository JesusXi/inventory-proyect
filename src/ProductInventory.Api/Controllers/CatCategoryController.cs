using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatCategory.Application.UseCases.CatCategory.Update;
using ProductInventory.Application.UseCases.CatCategory.Create;
using ProductInventory.Application.UseCases.CatCategory.Delete;
using ProductInventory.Application.UseCases.CatCategory.Get;
using ProductInventory.Application.UseCases.CatCategory.Update;


namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    [Authorize]
    public class CatCategoryController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetCatCategoryHandler handler) => Ok(await handler.ExecuteAsync(true));
        [HttpPost("AddCategory")]
        public async Task<IActionResult> Create([FromServices] CreateCatCategoryHandler handler, [FromBody] CreateCatCategoryCommand command)
        {
            await handler.ExecuteAsync(command);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromServices] UpdateCatCategoryHandler handler, [FromBody] UpdateCatCategoryCommand command)
        {
            await handler.ExecuteAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DeleteCatCategoryHandler handler)
        {
            handler.ExecuteAsync(id);
            return NoContent();
        }
    }
}
