using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(
        IProductRepository productRepository
    )
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }

    public async Task SaveProduct(Product product)
    {
        await _productRepository.SaveProduct(product);
    }
}