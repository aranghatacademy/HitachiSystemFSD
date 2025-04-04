using System;
using Ecom.Entities;

namespace Ecom.Data;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> GetByEmail(string email);
}
