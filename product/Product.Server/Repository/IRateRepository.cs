using product.Models;

namespace product.Repository;

public interface IRateRepository
{
    Task<List<RateEntity>> GetAllRating();
    Task SaveRating(RateEntity rateToSave);
}