using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using product.Controllers;
using product.Dto;
using product.Service;
using Xunit;
using Assert = Xunit.Assert;

namespace Product.UnitTests.Controllers;

//[TestFixture]
public class ProductControllerTest
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _mockProductService = new Mock<IProductService>();

    public ProductControllerTest()
    {
        _productController = new ProductController(_mockProductService.Object);
    }

    [Fact]
    public async Task GetAllProducts_ShouldReturn200_WhenExecuted()
    {
        // Arrange
        var productDtoList = new List<ProductDto>() { new ProductDto(){Id = Guid.NewGuid()}};
        
        _mockProductService
            .Setup(x => x.GetAllProducts())
            .ReturnsAsync(productDtoList);
        
        // Act
        var result = await _productController.GetAllProducts() as ObjectResult;
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode) result.StatusCode);
        Assert.Equal(productDtoList, result.Value);
        _mockProductService.Verify(x => x.GetAllProducts(), Times.Once);
    }
}