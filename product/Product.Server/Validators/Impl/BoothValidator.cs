using product.Exceptions;
using product.Repository;
using product.Validators;

namespace Product.Validators.Impl;

public class BoothValidator : IBoothValidator
{

    private readonly IBoothRepository _boothRepository;

    public BoothValidator(IBoothRepository boothRepository)
    {
        _boothRepository = boothRepository;
    }

    public void ValidateBoothDelete(Guid id)
    {
        if (!_boothRepository.CheckIfBoothExists(id))
        {
            throw new ItemNotFoundException("Following booth id doesn't exists: " + id);
        }
    }
}