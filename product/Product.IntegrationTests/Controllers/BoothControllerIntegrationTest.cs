using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Booth.IntegrationTests.Utils;
using Newtonsoft.Json;
using product.Dto;
using Product.IntegrationTests.Config;
using Product.IntegrationTests.Utils;
using product.Models;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class BoothControllerIntegrationTest : BaseTestFixture
{
    public BoothControllerIntegrationTest(TestingWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task PostBooth_CreatesBooth()
    {
        // Arrange
        var boothToCreateDto = BoothObjectProvider.ProvideCreateBoothDto();
        
        // Act
        var response = await _client.PostAsync("/booth", new StringContent(JsonConvert.SerializeObject(boothToCreateDto), Encoding.Default, "application/json"));

        // Assert
        
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.Contains(boothToCreateDto.Title, response.Content.ReadAsStringAsync().Result);
        Assert.Contains(boothToCreateDto.Description, response.Content.ReadAsStringAsync().Result);
    }

    [Fact]
    public async Task GetBooth_ReturnsAllBooths()
    {
        // Arrange
        List<ProductEntity> allEntities = _context.Product.ToList();

        // Act
        var response = await _client.GetAsync("/booth");
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.True(allEntities.TrueForAll(product => response.Content.ReadAsStringAsync().Result.Contains(product.Title)));
        Assert.True(allEntities.TrueForAll(product => response.Content.ReadAsStringAsync().Result.Contains(product.Description)));
    }

    [Fact]
    public async Task DeleteBooth_RemovesBoothById()
    {
        // Arrange

        // Act

        // Assert
    }
}