using product.Models;

namespace product.Repository;

public interface IRateRepository
{
    Task<List<Rate>> GetAllRating();
    Task SaveRating(Rate rateToSave);
}