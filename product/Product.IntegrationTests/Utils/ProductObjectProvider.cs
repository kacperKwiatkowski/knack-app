﻿using System;
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

    public static CreateProductDto ProvideCreateProductDto(Guid boothId)
    {
        return new CreateProductDto()
        {
            BoothId = boothId,
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }

    public static ProductEntity ProvideProductEntity()
    {
        return new ProductEntity()
        {
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }
}