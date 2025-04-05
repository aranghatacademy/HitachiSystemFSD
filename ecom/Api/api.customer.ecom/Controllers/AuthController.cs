using System.Security.Authentication;
using Ecom.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.customer.ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthenticationService authenticationService, ILogger<AuthController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var claims = await _authenticationService.LoginAsync(request);
                var jwtToken = await _authenticationService.GenerateJwtToken(claims);
                return Ok(new { token = jwtToken });
            }
            catch (AuthenticationException ex)
            {
                _logger.LogError(ex, "Authentication failed");
                return Unauthorized();  
            }
        }
        
    }
}
