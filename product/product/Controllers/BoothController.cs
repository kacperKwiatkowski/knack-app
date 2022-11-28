using Microsoft.AspNetCore.Mvc;
using product.Data;
using product.Models;
using product.Service;

namespace product.Controllers;

[Route("[Controller]")]
[ApiController]
public class BoothController : ControllerBase
{
    private readonly ProductDbContext _dbContext;

    public BoothController(
        ProductDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }
}