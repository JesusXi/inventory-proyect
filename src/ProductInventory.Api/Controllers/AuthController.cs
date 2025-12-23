using Microsoft.AspNetCore.Mvc;
using ProductInventory.Application.UseCases.Login;
namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;

        public AuthController(LoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _loginHandler.ExecuteAsync(command);
            return Ok(result);
        }
    }
}
