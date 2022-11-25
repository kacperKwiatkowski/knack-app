using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;
using product.Service;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductDbContext _dbContext;
    private readonly IProductService _productService;

    public ProductController(
        ProductDbContext dbContext,
        IProductService productService
    )
    {
        _dbContext = dbContext;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _productService.GetAllProducts());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        await _productService.SaveProduct(product);
        return Ok();
    }
}