using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IBoothRepository _boothRepository;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository, 
        IBoothRepository boothRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _boothRepository = boothRepository;
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
        return _productRepository.DeleteProduct(productId);
    }
}