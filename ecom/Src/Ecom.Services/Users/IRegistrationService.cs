using System;
using Ecom.Entities;

namespace Ecom.Services.Users;

public interface IRegistrationService
{
    Task<Customer> RegisterCustomerAsync(RegistrationRequest request);
}
