using Microsoft.AspNetCore.Mvc;
using product.Models;

namespace product.Service;

public interface IRateService
{
    Task<List<Rate>> GetAllRatings();
    Task SaveRating(Rate rateToSave);
}