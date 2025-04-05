using System;
using System.Security.Authentication;
using System.Security.Claims;
using Ecom.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Ecom.Entities;

namespace Ecom.Services.Users;

public class AuthenticationService : IAuthenticationService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IConfiguration _configuration;

    public AuthenticationService(ICustomerRepository customerRepository
                    , ILogger<AuthenticationService> logger
                    , IConfiguration configuration)
    {
        _customerRepository = customerRepository;
        _logger = logger;
        _configuration = configuration;
    }

    public Task<string> GenerateJwtToken(List<Claim> claims)
    {
        //Get the secret key from the configuration
        var secretKey = _configuration["JWT:SigningKey"];
        var key       = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds     = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Ecom",
            audience: "Ecom",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<List<Claim>> LoginAsync(LoginRequest request)
    {
        var customer = await _customerRepository.GetByEmail(request.Email);
        if(customer == null)
        {
            _logger.LogError("Customer not found");
            throw new AuthenticationException("Customer not found");
        }

        if(new PasswordHasher<Customer>()
                    .VerifyHashedPassword(customer, customer.Password, request.Password) == PasswordVerificationResult.Failed)
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
