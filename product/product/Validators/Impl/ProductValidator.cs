using System.ComponentModel.DataAnnotations;
using product.Dto;
using product.Exceptions;
using product.Repository;

namespace product.Validators.Impl;

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
            throw new ItemNotFoundException("Following Product id doesn't exists");
        }
    }
}