using product.Models;

namespace product.Repository;

public interface IBoothRepository
{
    Task SaveBoothWithProduct(BoothEntity booth);
    Task<List<BoothEntity>> GetAllBooths();
    Task DeleteBooth(Guid id);
    Task SaveBooth(BoothEntity boothToSave);
    Task<BoothEntity?> GetBoothById(Guid boothId);
}