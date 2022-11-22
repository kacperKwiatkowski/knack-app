using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;

namespace product.Controllers;

[Route("[Controller]")]
public class ProductController : ControllerBase
{
    private ApiDbContext _dbContext;

    public ProductController(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _dbContext.Products;
    }

    [HttpPost]
    public void Post([FromBody] Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }
}