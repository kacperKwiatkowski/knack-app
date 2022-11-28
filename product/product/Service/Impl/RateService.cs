using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class RateService : IRateService
{
    private readonly IRateRepository _rateRepository;

    public RateService(
        IRateRepository rateRepository
    )
    {
        _rateRepository = rateRepository;
    }

    public Task<List<Rate>> GetAllRatings()
    {
        return _rateRepository.GetAllRating();
    }

    public Task SaveRating(Rate rateToSave)
    {
        return _rateRepository.SaveRating(rateToSave);
    }
}