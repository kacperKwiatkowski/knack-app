using Microsoft.AspNetCore.Mvc;
using product.Dto;
using product.Models;

namespace product.Service;

public interface IBoothService
{
    Task<List<BoothDto>> GetAllBooths();
    Task DeleteBooth(Guid id);
    Task SaveBooth(CreateBoothDto boothToSave);
}