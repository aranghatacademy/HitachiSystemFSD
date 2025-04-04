using System;
using Ecom.Data;
using Ecom.Entities;
using Microsoft.Extensions.Logging;

namespace Ecom.Services.Users;

public class RegistrationService : IRegistrationService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<RegistrationService> _logger;

    public RegistrationService(ICustomerRepository customerRepository, ILogger<RegistrationService> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<Customer> RegisterCustomerAsync(RegistrationRequest request)
    {
         _logger.LogInformation("Registering customer: {Name}", request.Name);
         var customer = new Customer
         {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = "",
            Address = ""
         };

         customer = await _customerRepository.Add(customer);
         _logger.LogInformation("Customer registered successfully: {Name}", customer.Name);

         //ToDo : Send Welcome Email
         //ToDo : Sent a confirmation SMS

         return customer;
    }
}
