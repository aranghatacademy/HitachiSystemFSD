using System;
using Ecom.Entities;
using Microsoft.Extensions.Logging;

namespace Ecom.Data.REpositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly EcomDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(EcomDbContext context, ILogger<ProductRepository> logger)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<Product> Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
