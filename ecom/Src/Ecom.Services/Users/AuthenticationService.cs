using System;
using System.Security.Authentication;
using System.Security.Claims;
using Ecom.Data;
using Microsoft.Extensions.Logging;

namespace Ecom.Services.Users;

public class AuthenticationService : IAuthenticationService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(ICustomerRepository customerRepository, ILogger<AuthenticationService> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }


    public async Task<List<Claim>> LoginAsync(string email, string password)
    {
        var customer = await _customerRepository.GetByEmail(email);
        if(customer == null)
        {
            _logger.LogError("Customer not found");
            throw new AuthenticationException("Customer not found");
        }

        if(customer.Password != password)
        {
            _logger.LogError("Invalid password");
            throw new AuthenticationException("Invalid password");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, customer.Name),
            new Claim(ClaimTypes.Email, customer.Email),
            new Claim(ClaimTypes.Role, "Customer"),
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString())
        };

        return claims;
    }
}
