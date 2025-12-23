using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Application.UseCases.InventoryMovements.Create;
using ProductInventory.Application.UseCases.InventoryMovements.Get;


namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/inventory-movements")]
    [Authorize]
    public class InventoryMovementsController : ControllerBase
    {
        Guid UserId
        {
            get
            {
                var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

                if (string.IsNullOrEmpty(sub))
                    throw new UnauthorizedAccessException("Token does not contain user id");

                return Guid.Parse(sub);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetInventoryMovementsHandler handler) => Ok(await handler.ExecuteAsync(UserId));
        [HttpPost("AddMovement")]
        public async Task<IActionResult> Create([FromServices] CreateInventoryMovementsHandler handler, [FromBody] CreateInventoryMovementsCommand command)
        {
            await handler.ExecuteAsync(UserId, command);
            return Ok();
        }
    }
}
