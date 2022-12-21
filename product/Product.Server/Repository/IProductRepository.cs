using product.Models;

namespace product.Repository;

public interface IProductRepository
{
    Task<List<ProductEntity>> GetAllProducts();
    Task SaveProduct(ProductEntity product);
    Task DeleteProduct(Guid productId);
    bool CheckIfProductExists(Guid productId);
}