using product.Models;

namespace product.Service;

public interface IProductService
{
    Task<List<Product>> GetAllProducts();
    Task SaveProduct(Product product);
    Task DeleteProduct(Guid productId);
}