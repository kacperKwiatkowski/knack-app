using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Models;

namespace product.Repository.Impl;

public class BoothRepository : IBoothRepository
{
    private readonly ProductDbContext _productDbContext;

    public BoothRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
}