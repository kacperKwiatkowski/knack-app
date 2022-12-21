using System;
using product.Dto;
using product.Models;

namespace Booth.IntegrationTests.Utils;

public class BoothObjectProvider
{
    public static BoothDto ProvideBoothDto(Guid id)
    {
        return new BoothDto()
        {
            Id = id,
            Description = Guid.NewGuid().ToString(),
            Title = Guid.NewGuid().ToString()
        };
    }

    public static CreateBoothDto ProvideCreateBoothDto()
    {
        return new CreateBoothDto()
        {
            Description = Guid.NewGuid().ToString(),
            Title = Guid.NewGuid().ToString()
        };
    }

    public static BoothEntity ProvideBoothEntity(Guid id)
    {
        return new BoothEntity()
        {
            Id = id,
            Description = Guid.NewGuid().ToString(),
            Title = Guid.NewGuid().ToString()
        };
    }
}