using Microsoft.AspNetCore.Mvc;
using product.Dto;
using product.Models;
using product.Service;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class BoothController : ControllerBase
{
    private readonly IBoothService _boothService;

    public BoothController(IBoothService boothService)
    {
        _boothService = boothService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _boothService.GetAllBooths());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBoothDto boothToSave)
    {
        await _boothService.SaveBooth(boothToSave);
        return Ok();
    }

    [HttpDelete("{boothId:guid}")] 
    public async Task<IActionResult> Delete(Guid boothId)
    {
        await _boothService.DeleteBooth(boothId);
        return Ok();
    }
}