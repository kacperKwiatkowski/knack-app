using product.Repository;

namespace product.Service.Impl;

public class BoothService : IBoothService
{
    private readonly IBoothRepository _boothRepository;

    public BoothService(
        IBoothRepository boothRepository
    )
    {
        _boothRepository = boothRepository;
    }
}