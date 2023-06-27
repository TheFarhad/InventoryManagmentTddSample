namespace IM.Application.Tests.Unit;

using NSubstitute;
using FluentAssertions;
using Contract;
using Inventory;
using Domain.Inventory;

public class InventoryApplicationTests : IDisposable
{
    private readonly InventoryApplication _service;
    private readonly IInventoryRepository _repository;
    private InventoryCreateCommand _command;

    public InventoryApplicationTests()
    {
        _repository = Substitute.For<IInventoryRepository>();
        _service = InventoryApplication.New(_repository);
        _command = new InventoryCreateCommand
        {
            Price = 100,
            Product = "IPhone"
        };
    }

    [Fact]
    public void Should_Return_Trust_Id_When_Inventory_Defined()
    {
        // Arrange(setup fixture)
        _repository.Add(Arg.Any<Inventory>()).Returns(3);

        // Act(exercise)
        var response = _service.Create(_command);

        // Assert(verify)
        response.Should().Be(3);
    }

    [Fact]
    public void Should_Create_Inventory()
    {
        // Arrange(setup fixture)

        // Act(exercise)
        var response = _service.Create(_command);

        // Assert(verify)
        _repository.Received().Add(Arg.Any<Inventory>());
    }

    public void Dispose() { }
}
