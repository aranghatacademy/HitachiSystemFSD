using Ecom.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.customer.ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(IRegistrationService registrationService, ILogger<RegisterController> logger)
        {
            _registrationService = registrationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            try
            {
                var customer = await _registrationService.RegisterCustomerAsync(request);

                //Sent 200 OK if registration is successful
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering customer");
                return StatusCode(500, "Internal server error");
            }
        }
        

    }
}
