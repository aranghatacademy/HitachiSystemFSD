using System;
using Ecom.Data.Exceptions;
using Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecom.Data.REpositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly EcomDbContext _context;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(EcomDbContext context, ILogger<CustomerRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Customer> Add(Customer entity)
    {
         if(_context.Customers.Any(c => c.Email == entity.Email))
         {
            _logger.LogError("Customer already exists");

            //ToDo : Create and throw a custom exception DuplicateEmailException
            throw new DuplicateEmailException("Customer already exists");
         }

         _logger.LogDebug("New Customer Adding customer to database");

        entity.CreatedAt = DateTime.UtcNow;
         _context.Customers.Add(entity);
         await _context.SaveChangesAsync();

         _logger.LogInformation("Customer added successfully with id: {Id}", entity.Id);
         return entity;
    }

    public Task<Customer> Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> GetByEmail(string email)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if(customer == null)
        {
            _logger.LogError("Customer not found");

            //ToDo : Create and throw a custom exception CustomerNotFoundException
            throw new CustomerNotFoundException("Customer not found");
        }
        return customer;
    }

    public Task<Customer> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> Update(Customer entity)
    {
        throw new NotImplementedException();
    }
}
