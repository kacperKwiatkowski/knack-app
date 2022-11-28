using product.Models;

namespace product.Repository;

public interface IBoothRepository
{
    Task SaveBoothWithProduct(Booth booth);
    Task<List<Booth>> GetAllBooths();
    Task DeleteBooth(Guid id);
    Task SaveBooth(Booth boothToSave);
}