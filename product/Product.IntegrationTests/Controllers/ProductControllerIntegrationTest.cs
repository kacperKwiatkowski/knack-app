using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using product.Dto;
using Product.IntegrationTests.Config;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class ProductControllerIntegrationTest : IClassFixture<TestingWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductControllerIntegrationTest(
        TestingWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
    }

    [Fact]
    public async Task Test00()
    {
        
        // Arrange
        var boothToCreate = new CreateBoothDto()
        {
            Title = "TestTitle",
            Description = "TestDescription"
        };
    
        // Act
        var createBoothResponse = await _client.PostAsync("/booth", new StringContent(JsonConvert.SerializeObject(boothToCreate), Encoding.Default, "application/json"));
        var getBoothsResponse = await _client.GetAsync("/booth");
        var createBoothResult = createBoothResponse.Content.ReadAsStringAsync().Result;
        var getBoothsResult = getBoothsResponse.Content.ReadAsStringAsync().Result;
    
        var rawBoothId = getBoothsResult.Split("\"");
        Guid boothId = new Guid(rawBoothId[3]);
               
        var productToCreate = new CreateProductDto()
        {
            Title = "TestTitle",
            Description = "TestDescription",
            BoothId = boothId
        };
        
        var createProductResponse = await _client.PostAsync("/product", new StringContent(JsonConvert.SerializeObject(productToCreate), Encoding.Default, "application/json"));
        var getProductResponse = await _client.GetAsync("/product");
        var createProductResult = createProductResponse.Content.ReadAsStringAsync().Result;
        var getProductResult = getProductResponse.Content.ReadAsStringAsync().Result;
    
        // Assert
        Assert.True(getBoothsResult.Contains(boothToCreate.Title));
        Assert.True(getProductResult.Contains(boothToCreate.Description));
    }

    [Fact]
    public async Task Test01_PostUser_CreatesUser()
    {
        // Arrange
        CreateProductDto productDto = new CreateProductDto()
        {
            // BoothId = fixture._productDbContext.Booth.First().Id,
            Title = "TestTitle",
            Description = "TestDescription"
        };
        
        // Act
        var response = await _client.PostAsync("/product", new StringContent(JsonConvert.SerializeObject(productDto), Encoding.Default, "application/json"));
    
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task Test02_GetAllProducts_ReturnsAllProducts()
    {
        // Arrange
    
        // Act
        var response = await _client.GetAsync("/product");
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.Contains("TestTitle", response.Content.ReadAsStringAsync().Result);
    }
}