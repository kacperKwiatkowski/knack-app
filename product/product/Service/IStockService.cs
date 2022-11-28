using product.Models;

namespace product.Service;

public interface IStockService
{
    Task<List<Stock>> GetAllStock();
    Task SaveStock(Stock stockToSave);
}