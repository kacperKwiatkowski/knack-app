using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;
using product.Service;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService
    )
    {
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

    [HttpDelete("{productId}")] 
    public async Task<IActionResult> Delete(Guid productId)
    {
        await _productService.DeleteProduct(productId);
        return Ok();
    }
}