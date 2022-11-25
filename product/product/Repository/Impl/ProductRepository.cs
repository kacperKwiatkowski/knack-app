using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Models;

namespace product.Repository.Impl;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _productDbContext;

    public ProductRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public Task<List<Product>> GetAllProducts()
    {
        return _productDbContext.Products.ToListAsync();
    }

    public Task SaveProduct(Product product)
    {
        _productDbContext.Products.Add(product);
        return _productDbContext.SaveChangesAsync();
    }
}