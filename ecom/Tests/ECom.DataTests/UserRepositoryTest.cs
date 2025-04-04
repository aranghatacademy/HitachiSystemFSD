using Ecom.Data;
using Ecom.Data.REpositories.Customers;
using Ecom.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace ECom.DataTests;

public class UserRepositoryTest
{
    private ICustomerRepository _customerRepository;
    private EcomDbContext _context;
    private ILogger<CustomerRepository> _logger = new Mock<ILogger<CustomerRepository>>().Object;


    [SetUp]
    public void Setup()
    {
        _context = new EcomDbContext();
        _customerRepository = new CustomerRepository(_context, _logger);
    }

    [Test]
    public async Task AddCustomer_ValidData_ReturnsCustomer()
    {
        // Arrange
        var customer = new Customer { Address = "123 Main St"
            , Email = $"test{Guid.NewGuid()}@test.com"
            , Name = "Test Customer"
            , PhoneNumber = "1234567890"
            , Password = "abcd12345"
        };

        // Act
        var result = await _customerRepository.Add(customer);


        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.GreaterThan(0));
    }


    [Test]
    public async Task AddCustomer_ExistingEmail_ThrowsException()
    {
        // Arrange
        var customer = new Customer { Address = "123 Main St"
            , Email = $"test{Guid.NewGuid()}@test.com"
            , Name = "Test Customer"
            , PhoneNumber = "1234567890"
            , Password = "abcd12345"
        };

        // Act
        await _customerRepository.Add(customer);

        // Assert
        Assert.ThrowsAsync<Exception>(async () => await _customerRepository.Add(customer), "Customer already exists");
        
    }


    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
}
