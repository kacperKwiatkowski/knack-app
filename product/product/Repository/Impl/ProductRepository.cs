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
        return _productDbContext.Product.ToListAsync();
    }

    public Task SaveProduct(Product product)
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
        _productDbContext.Remove(new Product() { Id = productId });
        return _productDbContext.SaveChangesAsync();
    }
}