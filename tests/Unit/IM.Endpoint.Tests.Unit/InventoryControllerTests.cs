namespace IM.Endpoint.Tests.Unit;

using NSubstitute;
using FluentAssertions;
using Application.Contract;
using Controllers;

public class InventoryControllerTests : IDisposable
{
    private readonly InventoryController _controller;
    private readonly IInventoryApplication _inventoryApplication;
    private InventoryCreateCommand _command;

    public InventoryControllerTests()
    {
        _inventoryApplication = Substitute.For<IInventoryApplication>();
        _controller = new InventoryController(_inventoryApplication);
        _command = new InventoryCreateCommand
        {
            Price = 100,
            Product = "IPhone"
        };
    }

    [Fact]
    public void Should_Return_True_When_Call_Create()
    {
        const long id = 1;
        // Arrange(setup fixture)
        _inventoryApplication
            .Create(Arg.Any<InventoryCreateCommand>())
            .Returns(id);

        // Act(exercise)
        var response = _controller.Create(_command);

        // Assert(verify)
        response.Should().Be(id);
    }

    [Fact]
    public void Should_Call_Create_From_InventoryApplication()
    {
        // Arrange(setup fixture)

        // Act(exercise)
        var response = _controller.Create(_command);

        // Assert(verify)
        _inventoryApplication
            .Received()
            .Create(Arg.Any<InventoryCreateCommand>());
    }

    public void Dispose() { }
}
