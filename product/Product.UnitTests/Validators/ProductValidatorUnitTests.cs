using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using product.Exceptions;
using product.Repository;
using product.Validators.Impl;
using Assert = NUnit.Framework.Assert;

namespace Product.UnitTests.Validators;

[TestFixture]
public class ProductValidatorUnitTests
{
    private readonly ProductValidator _productValidator;
    private readonly Mock<IProductRepository> _mockProductRepository = new Mock<IProductRepository>();

    public ProductValidatorUnitTests()
    {
        _productValidator = new ProductValidator(_mockProductRepository.Object);
    }

    [Test]
    [ExpectedException(typeof(ItemNotFoundException))]
    public void NotAcceptId_ProductDoesntExistById_WillThrowException()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        _mockProductRepository
            .Setup(x => x.CheckIfProductExists(nonExistentId))
            .Returns(false);

        // Act
        ItemNotFoundException? thrownException = Assert.Throws<ItemNotFoundException>(delegate
            {
                _productValidator.ValidateProductDelete(nonExistentId);
            }
        );

        // Assert
        Assert.True(thrownException != null);
        Assert.True(thrownException.Message.Contains(nonExistentId.ToString()));
    }
}