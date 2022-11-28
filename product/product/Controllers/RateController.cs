using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;
using product.Service;
using product.Service.Impl;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class RateController : ControllerBase
{
    private readonly IRateService _rateService;

    public RateController(IRateService rateService)
    {
        _rateService = rateService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _rateService.GetAllRatings());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Rate rateToSave)
    {
        await _rateService.SaveRating(rateToSave);
        return Ok();
    }
}