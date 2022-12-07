using Microsoft.AspNetCore.Mvc;
using product.Dto;
using product.Filters;
using product.Service;

namespace product.Controllers;

[CustomExceptionFilter]
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
    public async Task<IActionResult> Post([FromBody] CreateProductDto product)
    {
        await _productService.SaveProduct(product);
        return Ok();
    }

    [HttpDelete("{productId:guid}")] 
    public async Task<IActionResult> Delete(Guid productId)
    {
        await _productService.DeleteProduct(productId);
        return Ok();
    }
}