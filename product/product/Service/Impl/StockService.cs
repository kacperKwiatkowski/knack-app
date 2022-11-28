using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(
        IStockRepository stockRepository
    )
    {
        _stockRepository = stockRepository;
    }

    public Task<List<Stock>> GetAllStock()
    {
        return _stockRepository.GetAllStock();
    }

    public Task SaveStock(Stock stockToSave)
    {
        return _stockRepository.SaveStock(stockToSave);
    }
}