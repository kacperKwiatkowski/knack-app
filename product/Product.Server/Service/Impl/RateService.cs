using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class RateService : IRateService
{
    private readonly IMapper _mapper;
    private readonly IRateRepository _rateRepository;

    public RateService(
        IMapper mapper,
        IRateRepository rateRepository)
    {
        _mapper = mapper;
        _rateRepository = rateRepository;
    }

    public async Task<List<RateDto>> GetAllRatings()
    {
        return _mapper.Map<List<RateDto>>(await _rateRepository.GetAllRating());
    }

    public Task SaveRating(CreateRateDto rateToSave)
    {
        return _rateRepository.SaveRating(_mapper.Map<RateEntity>(rateToSave));
    }
}