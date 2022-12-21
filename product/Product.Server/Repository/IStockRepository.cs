using product.Models;

namespace product.Repository;

public interface IStockRepository
{
    Task<List<StockEntity>> GetAllStock();
    Task SaveStock(StockEntity stockToSave);
}