using product.Models;

namespace product.Repository;

public interface IStockRepository
{
    Task<List<Stock>> GetAllStock();
    Task SaveStock(Stock stockToSave);
}