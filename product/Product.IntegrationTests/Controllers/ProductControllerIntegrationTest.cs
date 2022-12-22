using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using product.Dto;
using Product.IntegrationTests.Config;
using Product.IntegrationTests.Utils;
using product.Models;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class ProductControllerIntegrationTest : BaseTestFixture
{
    
    public ProductControllerIntegrationTest(TestingWebApplicationFactory<Program> factory) : base(factory)
    {
    }
    
    [Fact]
    public async Task PostProduct_CorrectDto_CreatesProduct()
    {
        // Arrange
        List<ProductEntity> productsBeforeOperation = _context.Product.ToList();
        CreateProductDto productDto = ProductObjectProvider.ProvideCreateProductDto(_context.Booth.First().Id);

        // Act
        var response = await _client.PostAsync("/product", new StringContent(JsonConvert.SerializeObject(productDto), Encoding.Default, "application/json"));
        
        // Assert
        List<ProductEntity> productsAfterOperation = _context.Product.ToList();

        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.NotEqual(productsAfterOperation, productsBeforeOperation);
        Assert.Contains(productsAfterOperation, p => p.Title.Equals(productDto.Title) && p.Description.Equals(productDto.Description));
    }
    
    [Fact]
    public async Task PostProduct_InvalidDto_FailsCreatingProduct()
    {
        // Arrange
        CreateProductDto invalidProduct = ProductObjectProvider.ProvideCreateProductDto(_context.Booth.First().Id);
        invalidProduct.Title = Guid.NewGuid().ToString();
        invalidProduct.Description = Guid.NewGuid().ToString();

        // Act
        var response = await _client.PostAsync("/product", new StringContent(JsonConvert.SerializeObject(invalidProduct), Encoding.Default, "application/json"));
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task GetAllProducts_FilledDatabase_ReturnsAllProducts()
    {
        // Arrange
        List<ProductEntity> allEntities = _context.Product.ToList();
    
        // Act
        var response = await _client.GetAsync("/product");

        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.True(allEntities.TrueForAll(product => response.Content.ReadAsStringAsync().Result.Contains(product.Title)));
        Assert.True(allEntities.TrueForAll(product => response.Content.ReadAsStringAsync().Result.Contains(product.Description)));
    }    
    
    [Fact]
    public async Task DeleteProduct_ExistingProductId_RemovesProduct()
    {
        // Arrange
        ProductEntity productToDelete = _context.Product.Add(ProductObjectProvider.ProvideProductEntity()).Entity;
        _context.SaveChanges();

        // Act
        var response = await _client.DeleteAsync("/product/" + productToDelete.Id);
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.Null(_context.Product.SingleOrDefault(product => product.Id == productToDelete.Id));
    }
    
    [Fact]
    public async Task DeleteProduct_NonExistingProductId_ReturnsFailureMessageAndStatus()
    {
        // Arrange
        var nonExistingProductId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync("/product/" + nonExistingProductId);

        var a = response.Content.ReadAsStringAsync().Result;
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        Assert.Contains(nonExistingProductId.ToString(), response.Content.ReadAsStringAsync().Result);
    }
}