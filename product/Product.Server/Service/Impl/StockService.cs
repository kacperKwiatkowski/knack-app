using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class StockService : IStockService
{
    private readonly IMapper _mapper;
    private readonly IStockRepository _stockRepository;

    public StockService(
        IMapper mapper,
        IStockRepository stockRepository)
    {
        _mapper = mapper;
        _stockRepository = stockRepository;
    }

    public async Task<List<StockDto>> GetAllStock()
    {
        return _mapper.Map<List<StockDto>>(await _stockRepository.GetAllStock());
    }

    public Task SaveStock(CreateStockDto stockToSave)
    {
        return _stockRepository.SaveStock(_mapper.Map<StockEntity>(stockToSave));
    }
}