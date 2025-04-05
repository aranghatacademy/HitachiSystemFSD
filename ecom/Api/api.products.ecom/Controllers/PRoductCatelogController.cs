
using Ecom.Data.REpositories.Products;
using Microsoft.AspNetCore.Mvc;

namespace api.products.ecom;

[Route("products/catalog")]
public class ProductCatalogController : Controller
{

     private readonly IProductRepository _productRepository;

     public ProductCatalogController(IProductRepository productRepository)
     {
        _productRepository = productRepository;
     }
    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAll();
        return View(products);
    }
}
