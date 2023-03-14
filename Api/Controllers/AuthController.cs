using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _AuthService;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService AuthService
            )
        {
            _logger = logger;
            _AuthService = AuthService;
        }

        [HttpGet("jwt")]
        public async Task<IActionResult> GetJwt() 
        {
            var result = await _AuthService.GetJwt();
            return Ok(result);
        }
    }
}
