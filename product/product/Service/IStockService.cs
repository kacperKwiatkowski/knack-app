using product.Dto;
using product.Models;

namespace product.Service;

public interface IStockService
{
    Task<List<StockDto>> GetAllStock();
    Task SaveStock(CreateStockDto stockToSave);
}