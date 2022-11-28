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
    
    public async Task<List<Booth>> GetAllBooths()
    {
        return await _productDbContext.Booth
            .ToListAsync();
    }

    public Task DeleteBooth(Guid boothId)
    {
        _productDbContext.Booth.Remove(new Booth() { Id = boothId });
         return _productDbContext.SaveChangesAsync();
    }

    public Task SaveBooth(Booth boothToSave)
    {
        _productDbContext.Booth.Add(boothToSave);
        return _productDbContext.SaveChangesAsync();
    }

    public Task SaveBoothWithProduct(Booth booth)
    {
        _productDbContext.AddRangeAsync(booth);
        return _productDbContext.SaveChangesAsync();
    }


}