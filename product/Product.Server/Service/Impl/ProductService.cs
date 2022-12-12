using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;
using product.Validators;

namespace product.Service.Impl;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IProductValidator _productValidator;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository, 
        IProductValidator productValidator)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _productValidator = productValidator;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        List<Product> fetchedProducts = await _productRepository.GetAllProducts();
        return _mapper.Map<List<ProductDto>>(fetchedProducts);
    }

    public async Task SaveProduct(CreateProductDto product)
    {
        //TODO (KKK) Temporary solution for REST validation
        await _productRepository.SaveProduct(_mapper.Map<Product>(product));
    }

    public Task DeleteProduct(Guid productId)
    {
        _productValidator.ValidateProductDelete(productId);
        return _productRepository.DeleteProduct(productId);
    }
}