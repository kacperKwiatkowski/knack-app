using System;
using product.Dto;
using product.Models;

namespace Product.IntegrationTests.Utils;

public class ProductObjectProvider
{
    public static ProductDto ProvideProductDto(Guid id)
    {
        return new ProductDto()
        {
            Id = id,
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }

    public static CreateProductDto ProvideCreateProductDto(Guid id)
    {
        return new CreateProductDto()
        {
            BoothId = id,
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }

    public static ProductEntity ProvideProductEntity(Guid id)
    {
        return new ProductEntity()
        {
            Id = id,
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }
}