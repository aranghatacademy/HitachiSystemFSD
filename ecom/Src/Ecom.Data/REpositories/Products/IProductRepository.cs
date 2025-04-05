using System;
using Ecom.Entities;

namespace Ecom.Data.REpositories.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByPage(int page, int pageSize);
}
