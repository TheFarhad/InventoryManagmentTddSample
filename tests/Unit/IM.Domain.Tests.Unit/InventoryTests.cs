namespace IM.Domain.Tests.Unit;

using FluentAssertions;
using Builder;
using Inventory.Exceptions;

public class InventoryTests : IDisposable
{
    private readonly InventoryTestBuilder testBuilder;

    public InventoryTests()
    {
        testBuilder = new InventoryTestBuilder();
    }

    [Fact]
    public void Should_Construct_Inventory()
    {
        // Arrange(setup fixture)
        const string product = "Mac";
        const double price = 100;

        // Act(exercise)
        var inventory = testBuilder
            .WithProduct(product)
            .WithPrice(price)
            .Build();

        // Assert(verify)
        inventory.Product.Should().Be(product);
        inventory.Price.Should().Be(price);
        inventory.InStock.Should().BeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Should_Throw_InvalidProductException_When_Product_IsNullOrEmpty(string product)
    {
        // Arrange


        // Act
        Action Actual = () => testBuilder
        .WithProduct(product)
          .Build();

        // Assert 
        Actual.Should().ThrowExactly<InvalidProductException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Should_Throw_InvalidPriceException_When_Price_IsInvalidValue(double price)
    {
        // Arrange


        // Act
        Action Actual = () => testBuilder
        .WithPrice(price)
         .Build();

        // Assert 
        Actual.Should().ThrowExactly<InvalidPriceException>();
    }

    public void Dispose() { }
}
