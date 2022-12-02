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
        _productDbContext.Product
            .Where(p => p.Id == rateToSave.Product.Id)
            .Include(p => p.Rates)
            .SingleOrDefault()
            .Rates.Add(rateToSave);
        
        return _productDbContext.SaveChangesAsync();
    }
}