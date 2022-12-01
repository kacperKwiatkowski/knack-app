using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllProducts()
    {
        return _mapper.Map<List<ProductDto>>(await _productRepository.GetAllProducts());
    }

    public async Task SaveProduct(CreateProductDto product)
    {
        await _productRepository.SaveProduct(_mapper.Map<Product>(product));
    }

    public Task DeleteProduct(Guid productId)
    {
        return _productRepository.DeleteProduct(productId);
    }
}