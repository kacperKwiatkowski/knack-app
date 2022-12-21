using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using product.Data;
using product.Dto;
using Product.IntegrationTests.Config;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class ProductControllerIntegrationTest : BaseTestFixture
{
    
    public ProductControllerIntegrationTest(TestingWebApplicationFactory<Program> factory) : base(factory)
    {
    }
    
    [Fact]
    public async Task Test01_PostUser_CreatesUser()
    {
        // Arrange
        List<product.Models.ProductEntity> productsBeforeOperation = _context.Product.ToList();
        CreateProductDto productDto = new CreateProductDto()
        {
            BoothId = _context.Booth.First().Id,
            Title = "TestTitle",
            Description = "TestDescription"
        };
        
        // Act
        var response = await _client.PostAsync("/product", new StringContent(JsonConvert.SerializeObject(productDto), Encoding.Default, "application/json"));
        
        // Assert
        List<product.Models.ProductEntity> productsAfterOperation = _context.Product.ToList();

        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.NotEqual(productsAfterOperation, productsBeforeOperation);
        Assert.Contains(productsAfterOperation, p => p.Title.Equals(productDto.Title) && p.Description.Equals(productDto.Description));
    }
    
    [Fact]
    public async Task Test02_GetAllProducts_ReturnsAllProducts()
    {
        // Arrange
    
        // Act
        var response = await _client.GetAsync("/product");

        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.Contains("seedProduct", response.Content.ReadAsStringAsync().Result);
    }
}