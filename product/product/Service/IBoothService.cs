using Microsoft.AspNetCore.Mvc;
using product.Models;

namespace product.Service;

public interface IBoothService
{
    Task<List<Booth>> GetAllBooths();
    Task DeleteBooth(Guid id);
    Task SaveBooth(Booth boothToSave);
}