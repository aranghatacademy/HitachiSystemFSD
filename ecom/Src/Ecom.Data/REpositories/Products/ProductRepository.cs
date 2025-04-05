using System;
using System.Text.Json;
using Ecom.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Ecom.Data.REpositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly EcomDbContext _context;
    private readonly ILogger<ProductRepository> _logger;
    //private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;

    public ProductRepository(EcomDbContext context, ILogger<ProductRepository> logger,
    IDistributedCache distributedCache)
    {
        _logger = logger;
        _context = context;
        _distributedCache = distributedCache;
    }
    public async Task<Product> Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        //Check if the products are in the cache
        var productsString = await _distributedCache.GetStringAsync("products");
        IEnumerable<Product> products = string.IsNullOrEmpty(productsString) ? null : JsonSerializer.Deserialize<IEnumerable<Product>>(productsString);
        if(products == null)
        {
            _logger.LogInformation("Products not found in cache, retrieving from database");
            //Get the products from the database
            products = await _context.Products.Where(D => D.IsAvailable && D.DeletedAt == null).ToListAsync();

            //Set the products in the cache
            await _distributedCache.SetAsync("products", JsonSerializer.SerializeToUtf8Bytes(products), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }
        else
            _logger.LogInformation("Products retrieved from cache");

        return products;
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProductsByPage(int page, int pageSize)
    {
        var products = await _context.Products.Where(d => d.IsAvailable && d.DeletedAt == null)
                                     .Skip((page - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();
        return products;
    }

    public Task<Product> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
