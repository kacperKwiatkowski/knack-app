using product.Exceptions;
using product.Repository;
using product.Validators;

namespace Product.Validators.Impl;

public class ProductValidator : IProductValidator
{

    private readonly IProductRepository _productRepository;

    public ProductValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void ValidateProductDelete(Guid id)
    {
        if (!_productRepository.CheckIfProductExists(id))
        {
            throw new ItemNotFoundException("Following product id doesn't exists: " + id);
        }
    }
}