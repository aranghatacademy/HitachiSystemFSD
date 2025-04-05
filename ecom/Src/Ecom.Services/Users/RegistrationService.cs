using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using Ecom.Data;
using Ecom.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecom.Services.Users;

public class RegistrationService : IRegistrationService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<RegistrationService> _logger;
    private readonly IConfiguration _configuration;

    public RegistrationService(ICustomerRepository customerRepository, ILogger<RegistrationService> logger, IConfiguration configuration)
    {
        _customerRepository = customerRepository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<Customer> RegisterCustomerAsync(RegistrationRequest request)
    {
         _logger.LogInformation("Registering customer: {Name}", request.Name);
         var customer = new Customer
         {
            Name = request.Name,
            Email = request.Email,
           
            PhoneNumber = "",
            Address = "",
            ApiKey = GenerateApiKey(request.Email, request.Password),
            ApiSecret = GenerateApiSecret(request.Email, request.Password)
         };

         customer.Password = new PasswordHasher<Customer>().HashPassword(customer, request.Password);

         customer = await _customerRepository.Add(customer);
         _logger.LogInformation("Customer registered successfully: {Name}", customer.Name);

         //ToDo : Send Welcome Email
         //ToDo : Sent a confirmation SMS

         return customer;
    }

    private string GenerateApiKey(string email,string password)
    {
        var secretKey = _configuration["ApiHashKeySecret"];
        SHA256 sha256 = SHA256.Create();
        var apiKey = email + password + secretKey;
        var apiKeyBytes = Encoding.UTF8.GetBytes(apiKey);
        var hashBytes = sha256.ComputeHash(apiKeyBytes);
        var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        return hashString;
    }

    private string GenerateApiSecret(string email,string password)
    {
        var secretKey = _configuration["ApiHashKeySecret"];
        SHA256 sha256 = SHA256.Create();
        var apiSecret = email + password + secretKey;
        var apiSecretBytes = Encoding.UTF8.GetBytes(apiSecret);
        var hashBytes = sha256.ComputeHash(apiSecretBytes);
        var hashString =  Convert.ToBase64String(hashBytes);
        return hashString;
    }

   
}
