using product.Dto;
using product.Models;

namespace product.Service;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProducts();
    Task SaveProduct(CreateProductDto product);
    Task DeleteProduct(Guid productId);
}