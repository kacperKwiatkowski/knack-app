using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class ProductControllerIntegrationTest
{
    [Fact]
    public async Task GetUser_ReturnsUsers()
    {
        await using var app = new WebApplicationFactory<Program>();
        using var client = app.CreateClient();

        var response = client.GetAsync("/product");
        
        Assert.True(response.Result.StatusCode == HttpStatusCode.OK);
    }
}