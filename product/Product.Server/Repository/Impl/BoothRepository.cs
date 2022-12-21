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
    
    public async Task<List<BoothEntity>> GetAllBooths()
    {
        return await _productDbContext.Booth
            .ToListAsync();
    }

    public Task DeleteBooth(Guid boothId)
    {
        _productDbContext.Booth.Remove(new BoothEntity() { Id = boothId });
         return _productDbContext.SaveChangesAsync();
    }

    public Task SaveBooth(BoothEntity boothToSave)
    {
        _productDbContext.Booth.Add(boothToSave);
        return _productDbContext.SaveChangesAsync();
    }

    public async Task<BoothEntity?> GetBoothById(Guid boothId)
    {
        return  await _productDbContext.Booth.FindAsync(boothId);
    }

    public Task SaveBoothWithProduct(BoothEntity booth)
    {
        _productDbContext.AddRangeAsync(booth);
        return _productDbContext.SaveChangesAsync();
    }


}