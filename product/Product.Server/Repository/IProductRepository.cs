﻿using product.Models;

namespace product.Repository;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task SaveProduct(Product product);
    Task DeleteProduct(Guid productId);
    bool CheckIfProductExists(Guid productId);
}