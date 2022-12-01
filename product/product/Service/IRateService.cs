using Microsoft.AspNetCore.Mvc;
using product.Dto;
using product.Models;

namespace product.Service;

public interface IRateService
{
    Task<List<RateDto>> GetAllRatings();
    Task SaveRating(CreateRateDto rateToSave);
}