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
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }

    public static CreateBoothDto ProvideCreateBoothDto()
    {
        return new CreateBoothDto()
        {
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }

    public static BoothEntity ProvideBoothEntity()
    {
        return new BoothEntity()
        {
            Description = Guid.NewGuid().ToString().Substring(0, 20),
            Title = Guid.NewGuid().ToString().Substring(0, 20)
        };
    }
}