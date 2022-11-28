using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Models;

namespace product.Repository.Impl;

public class RateRepository : IRateRepository
{
    private readonly ProductDbContext _productDbContext;

    public RateRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public Task<List<Rate>> GetAllRating()
    {
        return _productDbContext.Rate.ToListAsync();
    }

    public Task SaveRating(Rate rateToSave)
    {
        _productDbContext.Rate.Add(rateToSave);
        return _productDbContext.SaveChangesAsync();
    }
}