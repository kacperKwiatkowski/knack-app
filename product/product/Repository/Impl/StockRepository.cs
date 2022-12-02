using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Models;

namespace product.Repository.Impl;

public class StockRepository : IStockRepository
{
    private readonly ProductDbContext _productDbContext;

    public StockRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public Task<List<Stock>> GetAllStock()
    {
        return _productDbContext.Stock.ToListAsync();
    }

    public Task SaveStock(Stock stockToSave)
    {
        _productDbContext.Product
            .Where(p => p.Id == stockToSave.Product.Id)
            .Include(p => p.Stocks)
            .SingleOrDefault()
            .Stocks.Add(stockToSave);
        
        return _productDbContext.SaveChangesAsync();
    }
}