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

    public Task<List<ProductEntity>> GetAllProducts()
    {
        return _productDbContext.Product.ToListAsync();
    }

    public Task SaveProduct(ProductEntity product)
    {
        var parentBooth = _productDbContext.Booth
            .Where(b => b.Id == product.Booth.Id)
            .Include(b => b.Products)
            .SingleOrDefault();

        parentBooth.Products.Add(product);
        
        return _productDbContext.SaveChangesAsync();
    }

    public Task DeleteProduct(Guid productId)
    {
        _productDbContext.Product.Remove(new ProductEntity() { Id = productId });
        return _productDbContext.SaveChangesAsync();
    }

    public bool CheckIfProductExists(Guid productId)
    {
        return _productDbContext.Product.Any(p => p.Id == productId);
    }
}