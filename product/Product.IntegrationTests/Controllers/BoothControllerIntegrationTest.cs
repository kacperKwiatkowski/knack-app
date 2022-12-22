using System;
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
using product.Models;
using Xunit;

namespace Product.IntegrationTests.Controllers;

public class BoothControllerIntegrationTest : BaseTestFixture
{
    public BoothControllerIntegrationTest(TestingWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task PostBooth_CorrectDto_CreatesBooth()
    {
        // Arrange
        List<BoothEntity> boothsBeforeOperation = _context.Booth.ToList();
        CreateBoothDto boothDto = BoothObjectProvider.ProvideCreateBoothDto();

        // Act
        var response = await _client.PostAsync("/booth", new StringContent(JsonConvert.SerializeObject(boothDto), Encoding.Default, "application/json"));
        
        // Assert
        List<BoothEntity> boothsAfterOperation = _context.Booth.ToList();

        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.NotEqual(boothsAfterOperation, boothsBeforeOperation);
        Assert.Contains(boothsAfterOperation, b => b.Title.Equals(boothDto.Title) && b.Description.Equals(boothDto.Description));
    }

    [Fact]
    public async Task PostBooth_InvalidDto_FailsCreatingBooth()
    {
        // Arrange
        CreateBoothDto invalidBooth = BoothObjectProvider.ProvideCreateBoothDto();
        invalidBooth.Title = Guid.NewGuid().ToString();
        invalidBooth.Description = Guid.NewGuid().ToString();

        // Act
        var response = await _client.PostAsync("/booth", new StringContent(JsonConvert.SerializeObject(invalidBooth), Encoding.Default, "application/json"));
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetBooth_FilledDatabse_ReturnsAllBooths()
    {
        // Arrange
        List<BoothEntity> allEntities = _context.Booth.ToList();
    
        // Act
        var response = await _client.GetAsync("/booth");

        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.True(allEntities.TrueForAll(booth => response.Content.ReadAsStringAsync().Result.Contains(booth.Title)));
        Assert.True(allEntities.TrueForAll(booth => response.Content.ReadAsStringAsync().Result.Contains(booth.Description)));
    }

    [Fact]
    public async Task DeleteBooth_ExistingBoothId_RemovesBoothById()
    {
        // Arrange
        BoothEntity boothToDelete = _context.Booth.Add(BoothObjectProvider.ProvideBoothEntity()).Entity;
        _context.SaveChanges();
        var l = _context.Booth.ToList();

        // Act
        var response = await _client.DeleteAsync("/booth/" + boothToDelete.Id);
        
        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.OK);
        Assert.Null(_context.Booth.SingleOrDefault(booth => booth.Id == boothToDelete.Id));
    }    
    
    [Fact]
    public async Task DeleteBooth_NonExistingBoothId_ReturnsFailureMessageAndStatus()
    {
        // Arrange
        var nonExistingProductId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync("/booth/" + nonExistingProductId);
        
        var a = response.Content.ReadAsStringAsync().Result;

        // Assert
        Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        Assert.Contains((nonExistingProductId.ToString()), response.Content.ReadAsStringAsync().Result);
    }
}