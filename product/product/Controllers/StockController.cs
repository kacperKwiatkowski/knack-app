using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;
using product.Service;
using product.Service.Impl;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _stockService.GetAllStock());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Stock stockToSave)
    {
        await _stockService.SaveStock(stockToSave);
        return Ok();
    }
}