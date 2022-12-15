using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using product.Data;
using Xunit;

namespace Product.IntegrationTests.Config;

public class BaseTestFixture : IClassFixture<TestingWebApplicationFactory<Program>>
{
    protected readonly HttpClient _client;
    protected readonly ProductDbContext _context;

    public BaseTestFixture(TestingWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        _context = factory.Services.CreateScope().ServiceProvider.GetRequiredService<ProductDbContext>();
    }
}